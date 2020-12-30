using System;
using System.Windows.Forms;

namespace TrainWindowsFormsApp
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void startTrainButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fastTrainButton_Click(object sender, EventArgs e)
        {
            var fastTrain = new FastTrainForm();
            fastTrain.ShowDialog();
        }

        private void saveNewExercisesButton_Click(object sender, EventArgs e)
        {
            var saveNewExercises = new SaveNewExerciseForm();
            saveNewExercises.ShowDialog();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
