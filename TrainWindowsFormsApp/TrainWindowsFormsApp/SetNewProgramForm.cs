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
    public partial class SetNewProgramForm : Form
    {
        // Свойства элементов управления
        private int x = 12;
        private int y = 310;
        private readonly int buttonWidth = 60;
        private readonly int buttonHeight = 60;

        private Button createTrainDayButton;

        private Label transferLabel;
        private Control c;

        public SetNewProgramForm()
        {
            InitializeComponent();
        }

        private void SetNewProgramForm_Load(object sender, EventArgs e)
        {
            foreach (var exercise in Enum.GetValues(typeof(ExercisesType)))
            {
                exercisesTypesListBox.Items.Add(exercise);
            }

            createTrainDayButton = CreateButton("Создать день");
            createTrainDayButton.Click += CreateTrainDayButton_Click;

            c = sender as Control;
            c.Location = PointToClient(MousePosition);
            transferLabel = CreateLabel(c.Top, c.Left);
            transferLabel.Visible = false;
            transferLabel.Enabled = false;

            MouseMove += SetNewProgramForm_MouseMove;
        }
        //
        // Объект
        //
        private Button CreateButton(string initialText = "")
        {
            var button = new Button
            {
                BackColor = Color.YellowGreen,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 204),
                Text = initialText,
                Size = new Size(buttonWidth, buttonHeight),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(x, y)
            };
            Controls.Add(button);
            button.BringToFront();
            return button;
        }

        private Label CreateLabel(int _x, int _y)
        {
            var label = new Label
            {
                BackColor = Color.Red,
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 204),
                Size = new Size(500, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(_x, _y)
            };
            Controls.Add(label);
            label.BringToFront();
            return label;
        }
        //
        // События
        //
        private void SetNewProgramForm_MouseMove(object sender, MouseEventArgs e)
        {
            transferLabel.Location = e.Location;
        }

        private void CreateTrainDayButton_Click(object sender, EventArgs e)
        {
            CreateLabel(x, y);
            x += 510;
            createTrainDayButton.Location = new Point(x, y);
        }

        private void setProgramListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            transferLabel.Visible = true;
            transferLabel.Enabled = true;
            transferLabel.Text = e.ToString();

        }

    }
}
