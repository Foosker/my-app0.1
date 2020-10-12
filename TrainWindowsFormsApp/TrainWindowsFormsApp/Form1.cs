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
    public partial class warmUpForm : Form
    {
        private readonly int height = 60;       // Высота ЭУ
        private readonly int indentBetween = 10;    // Расстояние между ЭУ по горизонтали,
        private int indentUpEdge;                   // то же по вертикали.

        private Exercise[] exercises;
        private List<string> fullWarmUp;
        private int warmUpCount;

        private static Random random = new Random();

        private List<string> modifiers = new List<string>
        {
            "",
            "Блок : ",
            "Уворот " + AddOptions("вправо : ", "влево : ", "вниз : "),
            "Отскок " + AddOptions("назад : ", "вправо : ", "влево : "),
            "Шаг " + AddOptions("вперёд : ", "назад : ", "вправо : ", "влево : "),
            "Повтор удара : ",
            AddOptions("5") + " сильных ударов : ",
            AddOptions("10") + " быстрых ударов : "
        };

        public warmUpForm(Exercise[] array)
        {
            InitializeComponent();
            exercises = array;
        }

        private void warmUpForm_Load(object sender, EventArgs e)
        {
            InitMap();
        }

        private void InitMap()
        {
            GetFullWarmUp();

            for (int i = 0; i < warmUpCount; i++)
            {
                CreateLabel(50, i, 600);
            }
        }

        private void GetFullWarmUp()
        {
            foreach (var exercise in exercises)
            {
                fullWarmUp.Add(GetModifiers() + exercise.Text);
            }
            warmUpCount = fullWarmUp.Count();
        }

        private string GetModifiers()
        {
            return modifiers[random.Next(modifiers.Count())];
        }

        private static string AddOptions(params string[] options)
        {
            if (Int32.TryParse(options[0], out var result))
            {
                return random.Next(3, result).ToString();
            }
            return options[random.Next(options.Length)];            
        }

        private Label CreateLabel(int indentLeftEdge, int indexRow, int width)
        {   // Создание ячеек
            int x = indentLeftEdge;
            int y = indentUpEdge + indexRow * (indentBetween + height); // Формула расчёта координат эллемента по ординате

            var label = new Label
            {
                BackColor = Color.LightBlue,
                Font = new Font("Comic Sans MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 204),
                Size = new Size(width, height),
                Text = fullWarmUp[indexRow],
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(x, y)
            };
            Controls.Add(label);
            return label;
        }
    }
}
