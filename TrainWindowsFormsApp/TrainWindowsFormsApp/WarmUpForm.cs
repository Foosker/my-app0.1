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
    public partial class WarmUpForm : Form
    {
        private readonly int height = 60;           // Высота ЭУ
        private readonly int indentBetween = 15;    // Расстояние между ЭУ по горизонтали,
        private readonly int indentUpEdge = 60;     // то же по вертикали.

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

        public WarmUpForm(Exercise[] array, Form form)
        {            
            InitializeComponent();

            Location = new Point(form.Width, form.Top);

            exercises = array;
        }

        private void warmUpForm_Load(object sender, EventArgs e)
        {
            InitMap();

            var butt = new Button();
            butt.Click += Butt_Click;
            CancelButton = butt;
        }

        private void Butt_Click(object sender, EventArgs e)
        {
            Close();
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
            fullWarmUp = new List<string>();

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
                BackColor = Color.AntiqueWhite,
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
