using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrainWindowsFormsApp
{
    public partial class FastTrainForm : Form
    {
        private readonly int height = 60;           // Высота ЭУ
        private readonly int indentBetween = 10;    // Расстояние между ЭУ по горизонтали,
        private int indentUpEdge = 300;             // то же по вертикали.

        private TrainMainForm mainForm = new TrainMainForm();

        private Label[] labelsMap;
        private Button[] exercisesChangeButtons;
        private Button[] repeatButtons;
        private Button[] megaPlusButtons;

        private MyMessageBox message;

        private List<Exercise> deserializableData;
        private Exercise[] exercises;
        private int numberOfExercises;

        private List<ExercisesType> muscles = new List<ExercisesType>();
        private List<Button> nameExercisesButtons = new List<Button>();

        private string pathToExercise;

        public FastTrainForm()
        {
            InitializeComponent();
        }

        private void FastTrainForm_Load(object sender, EventArgs e)
        {
            muscles = GetExercisedMuscles();
            CreateButtons();
        }

        private void InitMap()
        {   // Заполнение формы ячейками и кнопками
            numberOfExercises = exercises.Count();

            labelsMap = new Label[numberOfExercises * 2];   // Количество упражнений умноженное на количество лейблов
            exercisesChangeButtons = new Button[numberOfExercises];
            repeatButtons = new Button[numberOfExercises];
            megaPlusButtons = new Button[numberOfExercises];

            for (int i = 0; i < numberOfExercises; i++)
            {
                var textLabel = CreateLabel(50, i, 650);
                labelsMap[i] = textLabel;
                textLabel.MouseClick += ExerciseName_MouseClick;   // Событие нажатия на текст с названием упражнения

                var loadLabel = CreateLabel(725, i, 200);
                labelsMap[i + numberOfExercises] = loadLabel;

                var repeatButton = CreateButton(950, i, 100);
                repeatButtons[i] = repeatButton;
                repeatButton.Click += RepeatButton_Click;  // Событие нажатия на кнопку

                var megaPlusButton = CreateButton(1060, i, 50, "⮝");
                megaPlusButtons[i] = megaPlusButton;
                megaPlusButton.Click += MegaPlusButton_Click;

            }
        }

        public void FillInTheTable()
        {   // Заполнение ячеек
            for (int i = 0; i < numberOfExercises; i++)
            {
                labelsMap[i].Text = exercises[i].Text;                                      // название упражнения
                labelsMap[i + numberOfExercises].Text = exercises[i].Load;                  // нагрузка
                repeatButtons[i].Text = exercises[i].Repeat.ToString(); // повторения
            }
        }

        private Button CreateButton(int indentLeftEdge, int indexRow, int width, string initialText = "")
        {   // Создание кнопок 
            int x = indentLeftEdge;
            int y = indentUpEdge + indexRow * (indentBetween + height);  // Формула расчёта координат эллемента по ординате

            var button = new Button
            {
                BackColor = Color.IndianRed,
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 204),
                Text = initialText,
                Size = new Size(width, height),
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
            int y = indentUpEdge + indexRow * (indentBetween + height); // Формула расчёта координат эллемента по ординате

            var label = new Label
            {
                BackColor = Color.LightBlue,
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 204),
                Size = new Size(width, height),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(x, y)
            };
            Controls.Add(label);
            label.BringToFront();
            return label;
        }
        private List<ExercisesType> GetExercisedMuscles()
        {
            var list = new List<ExercisesType>();

            for (int i = Array.IndexOf(Enum.GetValues(typeof(ExercisesType)), ExercisesType.Scapula);
                i < Enum.GetValues(typeof(ExercisesType)).Length;
                i++)
            {
                list.Add((ExercisesType)Enum.GetValues(typeof(ExercisesType)).GetValue(i));
            }
            return list;
        }

        private void CreateButtons()
        {
            var numberOfButtons = muscles.Count;

            var sizeY = 60;

            for (int i = 0; i < numberOfButtons; i++)
            {
                var button = new Button
                {
                    BackColor = Color.OrangeRed,
                    Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 204),
                    Text = muscles[i].ToString(),
                    Size = new Size(120, sizeY),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(12, 12 + sizeY * i)
                };
                button.Click += NameExerciseButton_Click;
                nameExercisesButtons.Add(button);
                Controls.Add(button);
            }
        }

        private void GetExercises()
        {
            Random random = new Random();

            deserializableData = mainForm.GetDeserializedData(pathToExercise);

            exercises = new Exercise[deserializableData.Count];
            for (int i = 0; i < deserializableData.Count; i++)
            {
                exercises[i] = deserializableData[i];
            }
        }

        private void Save(int index)
        {
            // Если количество изменённых повторов стало больше максимально допустимого пишем "МАХ",
            if (exercises[index].Repeat > exercises[index].MaxRepeat)
            {
                var form = new SetNewLoadForm(exercises[index]);
                form.ShowDialog();
                exercises[index].Repeat = 10;
                exercises[index].Load = form.NewLoad;
            }

            var serializableData = JsonConvert.SerializeObject(deserializableData, Formatting.Indented);
            FileProvider.Save(pathToExercise, serializableData);

            Close();
        }

        public void ExerciseName_MouseClick(object sender, MouseEventArgs e)
        {   // Показ примечания к упражнению
            message = new MyMessageBox();
            var index = Array.IndexOf(labelsMap, sender); // Получаем индекс лейбла, на который нажали
            message.ShowText(exercises[index].Remark);     // и выводим примечание к упражнению по полученному индексу.            
        }

        public void RepeatButton_Click(object sender, EventArgs e)
        {   // Нажатие на кнопку выполнения упражнения
            var doneButton = (sender as Button);
            var index = Array.IndexOf(repeatButtons, doneButton);              // Получаем индекс кнопки в её специальном массиве,
            exercises[index].Repeat++;                                       // меняем значение числа повторов.

            Save(index);
        }

        public void MegaPlusButton_Click(object sender, EventArgs e)
        {   // Нажатие на кнопку 
            var megaButton = (sender as Button);    // Обращается к кнопке,
            var index = Array.IndexOf(megaPlusButtons, megaButton);              // Получаем индекс кнопки в её специальном массиве,
            exercises[index].Repeat++;                                       // меняем значение числа повторов.

            Save(index);
        }

        private void NameExerciseButton_Click(object sender, EventArgs e)
        {
            var nameButton = (sender as Button);

            pathToExercise = "ExercisesType/" + nameButton.Text + ".json";

            foreach (var button in nameExercisesButtons)
            {
                Controls.Remove(button);
            }
            GetExercises();
            InitMap();
            FillInTheTable();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FastTrainForm_SizeChanged(object sender, EventArgs e)
        {
            closeButton.Location = new Point(ClientSize.Width - closeButton.Width - 10, ClientSize.Height - closeButton.Height - 90);
            quitButton.Location = new Point(ClientSize.Width - quitButton.Width - 10, ClientSize.Height - quitButton.Height - 50);
        }
    }
}
