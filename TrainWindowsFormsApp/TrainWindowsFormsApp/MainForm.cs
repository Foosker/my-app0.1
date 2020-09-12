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
        private int indentUpEdge = 60;

        private Label[] labelsMap;
        private Button[] executedButtons;
        private MyMessageBox message;
        private Exercise[] exercises;
        private List<ExercisesType> exerciseTypes;
        private int numberOfExercises;
        private List<string> pathsList = new List<string>();  // Массив для хранения всех путей к файлам нужен для сохранения результатов в конце тренировки

        static Random random = new Random();
        private int progress;

        public MainForm()
        {
            InitializeComponent();

            BackgroundImage = SetImage();
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            progress = GetProgress();
            exercises = GetArrayExercises();
            InitMap();
            FillInTheTable();
        }
        //
        // Создание клиентской области
        //
        private Image SetImage()
        {
            var imageList = new Image[7] { Resources.Chevelle, Resources.CyberPunk1, Resources.Delorian,
                Resources.god_of_war_x_star_wars_baby_yoda_arriva_nell_esclusiva_ps4_fan_art_v3_414575,
                Resources.Mustang, Resources.oboi7_com_58309, Resources._3_9___Dethzazz };

            var randomImage = imageList[random.Next(imageList.Length - 1)];

            return randomImage;
        }

        private void InitMap()
        {   // Заполнение формы ячейками и кнопками
            labelsMap = new Label[numberOfExercises * 3];   // Количество упражнений умноженное на количество лейблов
            executedButtons = new Button[numberOfExercises];

            for (int i = 0; i < numberOfExercises; i++)
            {
                if (// Если это упражнение
                    (i > 0 &&
                    (exerciseTypes[i] > ExercisesType.ExtensorBack ||
                    // или следующее - односторонее,
                    exerciseTypes[i - 1] > ExercisesType.ExtensorBack)) || 
                    // либо прошлые два - двустороние,
                    (i > 2 &&
                    exerciseTypes[i - 1] <= ExercisesType.ExtensorBack && 
                    exerciseTypes[i - 2] <= ExercisesType.ExtensorBack) &&
                    exerciseTypes[i - 3] > ExercisesType.ExtensorBack)
                {   // то надо увеличить вертикальный отступ
                    indentUpEdge += 40;
                }

                var textLabel = CreateLabels(50, i, 650);
                Controls.Add(textLabel);
                labelsMap[i] = textLabel;
                textLabel.MouseClick += ExerciseName_MouseClick;   // Событие нажатия на текст с названием упражнения

                var loadLabel = CreateLabels(750, i, 200);
                Controls.Add(loadLabel);
                labelsMap[i + numberOfExercises] = loadLabel;

                var repeatLabel = CreateLabels(1000, i, 100);
                Controls.Add(repeatLabel);
                labelsMap[i + numberOfExercises * 2] = repeatLabel;

                var executedButton = CreateButton(1150, i, 100);
                // Имя кнопки состоит только из цифры от 0 до 6, для более удобного получения индекса в событии нажатия кнопки
                executedButton.Name = i.ToString();
                Controls.Add(executedButton);
                executedButtons[i] = executedButton;
                executedButton.Click += Button_Click;  // Событие нажатия на кнопку

            }
        }

        private Button CreateButton(int indentLeftEdge, int indexRow, int width)
        {   // Создание кнопок 
            int x = indentLeftEdge;
            int y = indentUpEdge + indexRow * (indentBetween + cellHeight);  // Формула расчёта координат эллемента по ординате

            var button = new Button
            {
                BackColor = Color.IndianRed,
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, (byte)204),
                Text = "NOK",
                Size = new Size(width, 60),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(x, y)
            };
            return button;
        }

        private Label CreateLabels(int indentLeftEdge, int indexRow, int width)
        {   // Создание ячеек
            int x = indentLeftEdge;
            int y = indentUpEdge + indexRow * (indentBetween + cellHeight); // Формула расчёта координат эллемента по ординате

            var label = new Label
            {
                BackColor = Color.LightBlue,
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, (byte)204),
                Size = new Size(width, 60),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(x, y)
            };
            return label;
        }

        private void FillInTheTable()
        {   // Заполнение ячеек
            for (int i = 0; i < 6; i++)
            {
                labelsMap[i].Text = exercises[i].Text;                                      // название упражнения
                labelsMap[i + numberOfExercises].Text = exercises[i].Load;                   // нагрузка
                labelsMap[i + numberOfExercises * 2].Text = exercises[i].Repeat.ToString();  // повторения
            }
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

        private Exercise[] GetArrayExercises()
        {
            var trainDay = progress % TrainDay.trainingOptions;

            exerciseTypes = TrainDay.Get(trainDay);  // Получаем список тренируемых мышц
            numberOfExercises = exerciseTypes.Count;

            var differentExecriseTypes = exerciseTypes.Distinct().ToList<ExercisesType>();
            var numberDifferentExercises = differentExecriseTypes.Count();

            var exerciseArray = new Exercise[numberOfExercises];  // Создание массива, куда будут добавляться упражнения

            for (int i = 0; i < numberDifferentExercises; i++)
            {
                var pathExerciseFile = "ExercisesType/" + differentExecriseTypes[i].ToString() + ".json";   // Название упражнения преобразуем в путь к файлу
                pathsList.Add(pathExerciseFile);                                                            // и добавляем в список всех путей.
                
                var dataExercises = FileProvider.GetData(pathExerciseFile);                                        // Получение данных из файла
                var deserializableDataExercises = JsonConvert.DeserializeObject<List<Exercise>>(dataExercises);    // и десериализация в список.

                for(int j = i; j < numberOfExercises; j++)
                {
                    if (differentExecriseTypes[i] == exerciseTypes[j])
                    {
                        var exerciseIndex = progress % deserializableDataExercises.Count;  // Индекс упражнения

                        var exercise = deserializableDataExercises[exerciseIndex];  // Выбор упражнения по индексу,
                        exerciseArray[j] = exercise;                                // добавление его в основной массив,
                        deserializableDataExercises.Remove(exercise);               // удаление из списка файла.
                    }
                }                    
                
            }
            return exerciseArray;
        }

        private Exercise[] GetArrayWarmUp()
        {
            var random = new Random();

            var warmUpTypes = TrainDay.GetWarmUpList();
            var numberOfWarmUp = warmUpTypes.Count;

            var differentWarmUp = warmUpTypes.Distinct().ToList<ExercisesType>();
            var numberDifferentWarmUp = differentWarmUp.Count();

            var warmUpArray = new Exercise[numberOfWarmUp];  // Создание массива, куда будут добавляться упражнения

            for (int i = 0; i < numberDifferentWarmUp; i++)
            {
                var pathWarmUpFile = "ExercisesType/" + differentWarmUp[i].ToString() + ".json"; // Название упражнения преобразуем в путь к файлу,

                var dataWarmUp = FileProvider.GetData(pathWarmUpFile);                                    // Получение данных из файла
                var deserializableDataWarmUp = JsonConvert.DeserializeObject<List<Exercise>>(dataWarmUp); // и десериализация в список.

                for (int j = i; j < numberOfWarmUp; j++)
                {
                    if (differentWarmUp[i] == warmUpTypes[j])
                    {
                        var warmUpIndex = random.Next(deserializableDataWarmUp.Count);  // Индекс упражнения

                        var warmUp = deserializableDataWarmUp[warmUpIndex]; // Выбор упражнения по индексу,
                        warmUpArray[j] = warmUp;                            // добавление его в основной массив,
                    }
                }
            }
            return warmUpArray;
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
            SaveProgress();
        }
        //
        // События
        //
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
            Exercise[] warmUp = GetArrayWarmUp();
            var warmUpShow = new MyMessageBox();
            var text = "";
            foreach (var warm in warmUp)
            {
                text += warm.Text + "\n";
            }
            warmUpShow.ShowText(text);
        }

        private void закончитьТренировкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveTrainResults();
            Close();
        }

        private void выходБезСохраненияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
