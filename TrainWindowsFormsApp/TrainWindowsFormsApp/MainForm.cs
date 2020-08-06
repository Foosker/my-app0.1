using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TrainWindowsFormsApp.Properties;

namespace TrainWindowsFormsApp
{
    public partial class MainForm : Form
    {
        public string pathToProgressFile = "progress.txt";

        private static int numberOfExercise = 6;  // Количество упражнений за тренировку

        private readonly int cellHeight = 60;
        private readonly int indentBetween = 10;
        private int indentUpEdge = 60;
        public int mapSize = numberOfExercise * 3;  // Колчество лейблов, соотношение (numberOfExercise * разновидности лейблов)


        private Label[] labelsMap;
        private Button[] executedButtons;
        MyMessageBox message;
        Exercise[] exercises;
        List<ExercisesType> exerciseTypes;
        List<string> pathsList = new List<string>();  // Массив для хранения всех путей к файлам нужен для сохранения результатов в конце тренировки

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
            labelsMap = new Label[mapSize];
            executedButtons = new Button[mapSize / 3];

            for (int i = 0; i < mapSize / 3; i++)
            {
                if (i > 0 &&
                    (exerciseTypes[i] > ExercisesType.ExtensorBack ||   // Если это упражнение или
                    exerciseTypes[i - 1] > ExercisesType.ExtensorBack)) // следующее - односторонее,
                {                                                       // то надо увеличить вертикальный отступ
                    indentUpEdge += 40;
                }

                var textLabel = CreateLabels(50, i, 650);
                Controls.Add(textLabel);
                labelsMap[i] = textLabel;
                textLabel.MouseClick += ExerciseName_MouseClick;   // Событие нажатия на текст с названием упражнения

                var loadLabel = CreateLabels(750, i, 200);
                Controls.Add(loadLabel);
                labelsMap[i + numberOfExercise] = loadLabel;

                var repeatLabel = CreateLabels(1000, i, 100);
                Controls.Add(repeatLabel);
                labelsMap[i + numberOfExercise * 2] = repeatLabel;

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
                labelsMap[i + numberOfExercise].Text = exercises[i].Load;                   // нагрузка
                labelsMap[i + numberOfExercise * 2].Text = exercises[i].Repeat.ToString();  // повторения
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
            
            var exerciseArray = new Exercise[exerciseTypes.Count];  // Создание массива, куда будут добавляться упражнения

            for (int i = 0; i < exerciseTypes.Count; i++)
            {
                var pathExerciseFile = "ExercisesType/" + exerciseTypes[i].ToString() + ".json"; // Название упражнения преобразуем в путь к файлу,

                if (!pathsList.Contains(pathExerciseFile))  // Если в списке путей к файлам с упражнениями нет нынешнего,
                {
                    pathsList.Add(pathExerciseFile);        // то он добавляется

                    var dataExercises = FileProvider.GetData(pathExerciseFile);                                        // Получение данных из файла
                    var deserializableDataExercises = JsonConvert.DeserializeObject<List<Exercise>>(dataExercises);    // и десериализация в список.

                    for(int j = i; j < exerciseTypes.Count; j++)
                    {
                        if (exerciseTypes[i] == exerciseTypes[j])
                        {
                            var exerciseIndex = progress / (TrainDay.trainingOptions - trainDay) % deserializableDataExercises.Count;  // Индекс упражнения

                            var exercise = deserializableDataExercises[exerciseIndex];  // Выбор упражнения по индексу,
                            exerciseArray[j] = exercise;                                // добавление его в основной массив,
                            deserializableDataExercises.Remove(exercise);               // удаление из списка из файла.
                        }
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
            if (exercises[index].Repeat > exercises[index].MaxRepeat) labelsMap[index + numberOfExercise * 2].Text = "MAX";
            // если нет - то меняем на новое значение.
            else labelsMap[index + numberOfExercise * 2].Text = exercises[index].Repeat.ToString();
        }

        private void сохранитьНовоеУпражнениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveExerc = new SaveNewExerciseForm();
            saveExerc.ShowDialog();
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
