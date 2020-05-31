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
    public partial class SaveNewExercise : Form
    {
        public SaveNewExercise()
        {
            InitializeComponent();
        }

        private void SaveNewExercise_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                exercisesTypeListBox.Items.Add((ExercisesType)i);
            }
        }
    }
}
