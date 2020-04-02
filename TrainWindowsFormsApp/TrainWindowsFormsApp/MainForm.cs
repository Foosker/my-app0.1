﻿using System;
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

        Exercise[] exercises;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitMap();
            exercises = GetListExercise();
            FillInTheTable();
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

        private Exercise[] GetListExercise()
        {
            var exercises = new Exercise[9];

            exercises[0] = new Exercise("Бег", 0, false, "Кроссовок, один", "Ногами");
            exercises[1] = new Exercise("Жим", 1, false, "Жми - разрешаю", "Руками");
            exercises[2] = new Exercise("Тяга", 2, false, "Тяни, ты всё равно меня не вытянишь", "Мыслями");
            exercises[3] = new Exercise("exerc3", 3, false, "load3", "remark3");
            exercises[4] = new Exercise("exerc4", 4, false, "load4", "remark4");
            exercises[5] = new Exercise("exerc5", 5, false, "load5", "remark5");
            exercises[6] = new Exercise("exerc6", 6, false, "load6", "remark6");
            exercises[7] = new Exercise("exerc7", 7, false, "load7", "remark7");
            exercises[8] = new Exercise("exerc8", 8, false, "load8", "remark8");

            return exercises;
        }

        private void FillInTheTable()
        {
            for (int i = 0; i < mapSize / 3; i++)
            {
                labelsMap[i].Text = exercises[i].text;
                labelsMap[i + 9].Text = exercises[i].load;
                labelsMap[i + 18].Text = exercises[i].repeat.ToString();
            }
        }
    }
}
