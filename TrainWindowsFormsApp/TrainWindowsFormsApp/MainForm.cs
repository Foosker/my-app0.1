using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainWindowsFormsApp
{
    public partial class MainForm : Form
    {
        string pathToProgressFile = "progress.txt";

        private readonly int cellHeight = 60;
        private readonly int indentBetween = 10;
        private int indentUpEdge = 60;
        public int mapSize = 27;

        private Label[] labelsMap;
        private Button[] executedButtons;
        MyMessageBox message;
        Exercise[] exercises;
        static Random random = new Random();
        string[] pathsArray = new string[3];  // Массив для хранения всех путей к файлам нужен для сохранения результатов в конце тренировки

        int progress;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            progress = GetProgress();
            InitMap();
            exercises = GetArrayExercises();
            FillInTheTable();
        }
        //
        // Создание клиентской области
        //
        private void InitMap()
        {   // Заполнение формы ячейками и кнопками
            labelsMap = new Label[mapSize];
            executedButtons = new Button[mapSize / 3];

            for (int i = 0; i < mapSize / 3; i++)
            {
                if (i % 3 == 0) indentUpEdge += 40;  // Если индекс элемента кратен 3, то переходим на следующую строку.
                var textLabel = CreateLabels(50, i, 650);
                Controls.Add(textLabel);
                labelsMap[i] = textLabel;
                textLabel.MouseClick += ExerciseName_MouseClick;   // Событие нажатия на текст с названием упражнения

                var loadLabel = CreateLabels(750, i, 200);
                Controls.Add(loadLabel);
                labelsMap[i + 9] = loadLabel;

                var repeatLabel = CreateLabels(1000, i, 100);
                Controls.Add(repeatLabel);
                labelsMap[i + 18] = repeatLabel;

                var executedButton = CreateButton(1150, i, 100);
                // Имя кнопки состоит только из цифры от 0 до 8, для более удобного получения индекса в событии нажатия кнопки
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
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204))),
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
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204))),
                Size = new Size(width, 60),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(x, y)
            };
            return label;
        }

        private void FillInTheTable()
        {   // Заполнение ячеек
            for (int i = 0; i < mapSize / 3; i++)
            {
                labelsMap[i].Text = exercises[i].Text;                    // название упражнения
                labelsMap[i + 9].Text = exercises[i].Load;                // нагрузка
                labelsMap[i + 18].Text = exercises[i].Repeat.ToString();  // повторения
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
            var exerciseArray = new Exercise[9];
            var exerciseTypes = TrainDay.Get(progress % 6);  // Получаем массив с видами упражнений
            for (int i = 0; i < exerciseTypes.Length; i++)
            {
                var pathExerciseFile = "ExercisesType/" + exerciseTypes[i].ToString() + ".json"; // Название упражнения преобразуем в путь к файлу,
                var data = FileProvider.GetData(pathExerciseFile);                               // получили данные из файла
                var deserializableData = JsonConvert.DeserializeObject<List<Exercise>>(data);    // и десериализовали в список.
                pathsArray[i] = pathExerciseFile;

                var index = i; // По этому значению будет присваиваться индекс упражнения в исходный массив
                for (int j = 0; j < 3; j++)
                {
                    var randomExercise = deserializableData[random.Next(deserializableData.Count)]; // Выбираем случайное упражнение,
                    deserializableData.Remove(randomExercise);                                      // удаляем его из списка,
                    exerciseArray[index] = randomExercise;                                          // вставляем его в исходный массив.
                    index += 3;  // Учеличивается по принципу: индекс 0-3-6, 1-4-7, 2-5-8.
                }
            }
            return exerciseArray;
        }
        
        private void SaveTrainResults()
        {
            for (int i = 0; i < pathsArray.Length; i++)
            {
                var data = FileProvider.GetData(pathsArray[i]);
                var deserializableData = JsonConvert.DeserializeObject<List<Exercise>>(data);
                var index = i;
                for (int j = 0; j < 3; j++)
                {
                    foreach (var exerc in deserializableData)
                    {
                        if (exerc.Text == exercises[index].Text) exerc.Repeat = exercises[index].Repeat;
                    }
                    var serializableData = JsonConvert.SerializeObject(deserializableData, Formatting.Indented);
                    FileProvider.Save(pathsArray[i], serializableData);
                    index += 3;
                }
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
            exercises[index].Repeat++;                                       // меняем значение числа повторов,
            labelsMap[index + 18].Text = exercises[index].Repeat.ToString(); // обновляем значение в ячейке.
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
