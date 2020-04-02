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
        public int mapSize = 9;

        private Label[] labelsMap;

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

            for (int i = 0; i < mapSize; i++)
            {
                if (i % 3 == 0) indentUpEdge += 40;
                var newLabel = CreateLabels(50, i, 600);
                Controls.Add(newLabel);
                labelsMap[i] = newLabel;                
            }   
        }

        private Label CreateLabels(int indentLeftEdge, int indexRow, int width)
        {
            int x = indentLeftEdge;
            int y = indentUpEdge + indexRow * (indentBetween + cellSize);

            var label = new Label
            {
                BackColor = Color.Red,
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
