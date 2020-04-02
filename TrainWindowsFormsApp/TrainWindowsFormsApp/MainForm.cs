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
        private readonly int cellSize = 60;
        private readonly int indentBetween = 10;
        private int indentUpEdge = 60;
        public int mapSize = 27;

        private Label[] labelsMap;
        private Button[] executedButtons;

        Exercise[] exercises = new Exercise[3];

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            exercises[0] = new Exercise("Бег", 3, false, "Кроссовок, один", "Ногами");
            exercises[1] = new Exercise("Жим", 3, false, "Жми - разрешаю", "Руками");
            exercises[2] = new Exercise("Тяга", 3, false, "Тяни, ты всё равно меня не вытянишь", "Мыслями");

            InitMap();
        }

        private void InitMap()
        {
            labelsMap = new Label[mapSize];
            executedButtons = new Button[mapSize / 3];

            for (int i = 0; i < mapSize / 3; i++)
            {
                if (i % 3 == 0) indentUpEdge += 40;
                var textLabel = CreateLabels(50, i, 650);
                Controls.Add(textLabel);
                labelsMap[i] = textLabel;

                var loadLabel = CreateLabels(750, i, 200);
                Controls.Add(loadLabel);
                labelsMap[i + 9] = loadLabel;

                var repeatLabel = CreateLabels(1000, i, 100);
                Controls.Add(repeatLabel);
                labelsMap[i + 18] = repeatLabel;

                var executedButton = CreateButton(1150, i, 100);
                Controls.Add(executedButton);
                executedButtons[i] = executedButton;
            }   
        }

        private Button CreateButton(int indentLeftEdge, int indexRow, int width)
        {
            int x = indentLeftEdge;
            int y = indentUpEdge + indexRow * (indentBetween + cellSize);

            var button = new Button
            {
                BackColor = Color.Goldenrod,
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204))),
                Text = "OK",
                Size = new Size(width, 60),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(x, y)
            };
            return button;            
        }

        private Label CreateLabels(int indentLeftEdge, int indexRow, int width)
        {
            int x = indentLeftEdge;
            int y = indentUpEdge + indexRow * (indentBetween + cellSize);

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

        private void exerciseLabel1_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show(exercises[0].remark);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
