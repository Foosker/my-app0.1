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
    public partial class SetNewLoadForm : Form
    {
        Exercise exercise;
        MyMessageBox message;

        public string NewLoad;

        public SetNewLoadForm(Exercise exercise)
        {
            InitializeComponent();

            this.exercise = exercise;
        }

        private void SetNewLoadForm_Load(object sender, EventArgs e)
        {
            currentExerciseLabel.Text = exercise.Text;
        }

        private bool IsValid()
        {
            if (String.IsNullOrWhiteSpace(newLoadTextBox.Text))
            {
                message = new MyMessageBox();
                message.ShowText("Введите нагрузку!");
                return false;
            }
            return true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                NewLoad = newLoadTextBox.Text;
                Close();
            }
        }
    }
}
