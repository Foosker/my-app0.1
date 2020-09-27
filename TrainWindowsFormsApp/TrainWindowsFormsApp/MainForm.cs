using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TrainWindowsFormsApp.Properties;

namespace TrainWindowsFormsApp
{
    public partial class MainForm : Form
    {
        private readonly string pathToProgressFile = "progress.txt";

        private readonly int cellHeight = 60;
        private readonly int indentBetween = 10;
        private int indentUpEdge;

        private Label[] labelsMap;
        private Button[] executedButtons;
        private Button[] megaPlusButtons;
        private MyMessageBox message;
        private Exercise[] exercises;
        private List<ExercisesType> exerciseTypes;
        private int numberOfExercises;
        private List<string> pathsList = new List<string>();  // Массив для хранения всех путей к файлам нужен для сохранения результатов в конце тренировки

        private static Random random = new Random();
        private int progress;

        private int timerCounter;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            progress = GetProgress();
            exercises = GetExercises();
            InitMap();
            FillInTheTable();
        }
        //
        // Клиентская область
        //
        private void InitMap()
        {   // Заполнение формы ячейками и кнопками
            numberOfExercises = exercises.Count();

            labelsMap = new Label[numberOfExercises * 3];   // Количество упражнений умноженное на количество лейблов
            executedButtons = new Button[numberOfExercises];
            megaPlusButtons = new Button[numberOfExercises];

            indentUpEdge = 60;

            var counter = 0; // Счётчик двустороних упражнений

            for (int i = 0; i < numberOfExercises; i++)
            {
                if (// Если это упражнение или предыдущее односторонее
                    (i > 0 &&
                    (exerciseTypes[i] > ExercisesType.D_Core ||
                    exerciseTypes[i - 1] > ExercisesType.D_Core)) ||
                    // или счётчик насчитал 3 упражнения,
                    counter >= 3)
                {   // то надо увеличить вертикальный отступ
                    indentUpEdge += 40;
                    counter = 0;
                }
                else
                {
                    counter++;
                }

                var textLabel = CreateLabel(50, i, 650);
                labelsMap[i] = textLabel;
                textLabel.MouseClick += ExerciseName_MouseClick;   // Событие нажатия на текст с названием упражнения

                var loadLabel = CreateLabel(750, i, 200);
                labelsMap[i + numberOfExercises] = loadLabel;

                var repeatLabel = CreateLabel(1000, i, 100);
                labelsMap[i + numberOfExercises * 2] = repeatLabel;

                var executedButton = CreateButton(1150, i, 100);
                // Имя кнопки состоит только из цифры от 0 до 6, для более удобного получения индекса в событии нажатия кнопки
                executedButton.Name = i.ToString();
                executedButtons[i] = executedButton;
                executedButton.Click += Button_Click;  // Событие нажатия на кнопку

                var megaPlusButton = CreateButton(1300, i, 100);
                // Имя кнопки состоит только из цифры от 10 до 16, для более удобного получения индекса в событии нажатия кнопки
                megaPlusButton.Name = (10 + i).ToString();
                megaPlusButtons[i] = megaPlusButton;
                megaPlusButton.Click += MegaPlusButton_Click;

            }
        }

        private void FillInTheTable()
        {   // Заполнение ячеек
            for (int i = 0; i < numberOfExercises; i++)
            {
                labelsMap[i].Text = exercises[i].Text;                                      // название упражнения
                labelsMap[i + numberOfExercises].Text = exercises[i].Load;                   // нагрузка
                labelsMap[i + numberOfExercises * 2].Text = exercises[i].Repeat.ToString();  // повторения
            }
        }

        private Button CreateButton(int indentLeftEdge, int indexRow, int width)
        {   // Создание кнопок 
            int x = indentLeftEdge;
            int y = indentUpEdge + indexRow * (indentBetween + cellHeight);  // Формула расчёта координат эллемента по ординате

            var button = new Button
            {
                BackColor = Color.IndianRed,
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 204),
                Text = "NOK",
                Size = new Size(width, 60),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(x, y)
            };
            Controls.Add(button);
            button.BringToFront();
            return button;
        }

        private Label CreateLabel(int indentLeftEdge, int indexRow, int width)
        {   // Создание ячеек
            int x = indentLeftEdge;
            int y = indentUpEdge + indexRow * (indentBetween + cellHeight); // Формула расчёта координат эллемента по ординате

            var label = new Label
            {
                BackColor = Color.LightBlue,
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 204),
                Size = new Size(width, 60),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(x, y)
            };
            Controls.Add(label);
            label.BringToFront();
            return label;
        }

        private void ClearField()
        {
            Array.Clear(exercises, 0, 6);

            while (Controls.Count > 2)
            {// Два члена Controls - верхняя панель и фоновая картинка
                Controls.RemoveAt(Controls.Count-2);
            }
        }

        private void LaunchAddon()
        {
            ClearField();
            exercises = GetExercises("additional");
            InitMap();
            FillInTheTable();

            mainTimer.Stop();
            timerCounter = 0;
        }

        private void GetMode()
        {
            var modes = new List<string>()
            {
                "Статическое удержание в пике",
                "1,5 повторения",
                "\"На смерть\" в каждом подходе",
                "Частичные повторения"
            };

            var selectedMode = modes[random.Next(modes.Count())];

            var modeLabel = CreateLabel(350, 7, 600);
            modeLabel.Font = new Font("Tahoma", 25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            modeLabel.ForeColor = Color.DarkOrange;
            modeLabel.Height = 200;
            modeLabel.Image = Resources.Fire;
            modeLabel.Text = selectedMode;
        }
        //
        // Работа с файлами
        //
        private int GetProgress()
        {
            var isExistFile = FileProvider.TryGet(pathToProgressFile, out var data);

            if (!isExistFile)
            {
                FileProvider.Save(pathToProgressFile, "1");
                data = "1";
            }
            return int.Parse(data);
        }

        private void SaveProgress()
        {
            progress++;
            var data = progress.ToString();

            FileProvider.Save(pathToProgressFile, data);
        }

        private Exercise[] GetExercises(string option = "train")
        {
            // Получаем список тренируемых мышц
            List<ExercisesType> exercisesList;

            if (option == "train")
            {
                exercisesList = TrainDay.GetTrain(progress);
                exerciseTypes = exercisesList;
            }
            else if (option == "additional")
            {
                exerciseTypes.Clear();
                exercisesList = TrainDay.GetAdditional();
                exerciseTypes = exercisesList;
            }
            else
            { 
                exercisesList = TrainDay.GetWarmUpList(); 
            }

            var exercisesCount = exercisesList.Count();

            var differentExecriseTypes = exercisesList.Distinct().ToList<ExercisesType>();
            var numberDifferentExercises = differentExecriseTypes.Count();

            var exerciseArray = new Exercise[exercisesCount];  // Создание массива, куда будут добавляться упражнения

            for (int i = 0; i < numberDifferentExercises; i++)
            {// Название упражнения преобразуем в путь к файлу
                var pathExerciseFile = "ExercisesType/" + differentExecriseTypes[i].ToString() + ".json";   
                // и добавляем в список всех путей, если это тренировка или дополнение к ней
                if (option != "warmUp") pathsList.Add(pathExerciseFile);

                // Получение данных из файла
                var dataExercises = FileProvider.GetData(pathExerciseFile);
                // и десериализация в список.
                var deserializableDataExercises = JsonConvert.DeserializeObject<List<Exercise>>(dataExercises);

                for (int j = i; j < exercisesCount; j++)
                {
                    if (differentExecriseTypes[i] == exercisesList[j])
                    {
                        int exerciseIndex;  // Индекс упражнения
                        if (option == "warmUp") exerciseIndex = random.Next(deserializableDataExercises.Count);
                        else if (option == "additional") exerciseIndex = (progress + 1) % deserializableDataExercises.Count;
                        else exerciseIndex = progress % deserializableDataExercises.Count;

                        var exercise = deserializableDataExercises[exerciseIndex];  // Выбор упражнения по индексу,
                        exerciseArray[j] = exercise;                                // добавление его в основной массив,
                        deserializableDataExercises.Remove(exercise);               // удаление из списка файла.
                    }
                }

            }
            return exerciseArray;
        }

        private void SaveTrainResults()
        {
            foreach (var exercise in exercises)
            {
                if (exercise.Repeat > exercise.MaxRepeat)
                {
                    var form = new SetNewLoadForm(exercise);
                    form.ShowDialog();
                    exercise.Repeat = 10;
                    exercise.Load = form.NewLoad;
                }
            }

            for (int i = 0; i < pathsList.Count; i++)
            {
                var data = FileProvider.GetData(pathsList[i]);
                var deserializableData = JsonConvert.DeserializeObject<List<Exercise>>(data);
                for (int j = 0; j < exercises.Length; j++)
                {
                    foreach (var exerc in deserializableData)
                    {
                        if (exerc.Text == exercises[j].Text)
                        {
                            exerc.Repeat = exercises[j].Repeat;
                            exerc.Load = exercises[j].Load;
                        }
                    }
                }
                var serializableData = JsonConvert.SerializeObject(deserializableData, Formatting.Indented);
                FileProvider.Save(pathsList[i], serializableData);
            }
        }
        //
        // События
        //
        private void mainTimer_Tick(object sender, EventArgs e)
        {
            timerCounter++;
            if (timerCounter > 2)
            {
                LaunchAddon();

            }
        }

        private void ExerciseName_MouseClick(object sender, MouseEventArgs e)
        {   // Показ примечания к упражнению
            message = new MyMessageBox();
            var index = Array.IndexOf(labelsMap, sender); // Получаем индекс лейбла, на который нажали
            message.ShowText(exercises[index].Remark);     // и выводим примечание к упражнению по полученному индексу.
            
        }

        private void Button_Click(object sender, EventArgs e)
        {   // Нажатие на кнопки
            var button = (sender as Button);        // Обращается к кнопке,
            button.BackColor = Color.ForestGreen;   // меняет окраску кнопки
            button.Text = "OK";                     // и текст на ней.
            button.Enabled = false;  // Отключение кнопки после нажатия.

            var name = button.Name;                                          // Получаем имя, которое состоит только из цифры,
            var index = int.Parse(name);                                     // преоразуем имя в индекс,
            exercises[index].Repeat++;                                       // меняем значение числа повторов.

            var megaButton = megaPlusButtons[index];
            megaButton.BackColor = Color.Gray;
            megaButton.Text = "N U";      
            megaButton.Enabled = false;

            // Если количество изменённых повторов стало больше максимально допустимого пишем "МАХ",
            if (exercises[index].Repeat > exercises[index].MaxRepeat) labelsMap[index + numberOfExercises * 2].Text = "MAX";
            // если нет - то меняем на новое значение.
            else labelsMap[index + numberOfExercises * 2].Text = exercises[index].Repeat.ToString();
        }

        private void MegaPlusButton_Click(object sender, EventArgs e)
        {
            // Нажатие на кнопки
            var megaButton = (sender as Button);    // Обращается к кнопке,
            megaButton.BackColor = Color.Gold; // меняет окраску кнопки
            megaButton.Text = "Yeah";               // и текст на ней.
            megaButton.Enabled = false;  // Отключение кнопки после нажатия.

            var name = megaButton.Name;                             // Получаем имя, которое состоит только из цифры,
            var index = int.Parse(name) - 10;                       // преоразуем имя в индекс минус 10,
            var megaRepeat = exercises[index].MaxRepeat / 10 + 1;   // получаем большее число чем 1,
            exercises[index].Repeat += megaRepeat;                  // и меняем значение числа повторов.
            // Отключение обычных кнопок
            var button = executedButtons[index];
            button.BackColor = Color.ForestGreen;
            button.Text = "OK";
            button.Enabled = false;

            // Если количество изменённых повторов стало больше максимально допустимого пишем "МАХ",
            if (exercises[index].Repeat > exercises[index].MaxRepeat) labelsMap[index + numberOfExercises * 2].Text = "MAX";
            // если нет - то меняем на новое значение.
            else labelsMap[index + numberOfExercises * 2].Text = exercises[index].Repeat.ToString();
        }

        private void сохранитьНовоеУпражнениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveExerc = new SaveNewExerciseForm();
            saveExerc.ShowDialog();
        }

        private void сформироватьРазминкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exercise[] warmUp = GetExercises("warmUp");
            var warmUpShow = new MyMessageBox();
            var text = "";
            foreach (var warm in warmUp)
            {
                text += warm.Text + "\n";
            }
            warmUpShow.ShowText(text);
        }

        private void мнеНехерДелатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            мнеНехерДелатьToolStripMenuItem.Enabled = false;
            дополнительныйРежимToolStripMenuItem.Enabled = true;
            backgroundPictureBox.BringToFront();
            mainTimer.Start();
            //SaveTrainResults();
        }

        private void дополнительныйРежимToolStripMenuItem_Click(object sender, EventArgs e)
        {
            дополнительныйРежимToolStripMenuItem.Enabled = false;
            GetMode();
        }

        private void закончитьТренировкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProgress();
            //SaveTrainResults();
            Close();
        }

        private void выходБезСохраненияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
