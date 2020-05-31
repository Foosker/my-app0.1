using Newtonsoft.Json;
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
    public partial class SaveNewExerciseForm : Form
    {
        string pathToExerciseFile;

        public SaveNewExerciseForm()
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

        private bool IsValid()
        {
            if (String.IsNullOrWhiteSpace(textTextBox.Text))
            {
                MessageBox.Show("Введите название упражнения!");
                return false;
            }

            if (!int.TryParse(repeatTextBox.Text, out int result))
            {
                MessageBox.Show("Введите количество повторений!");
                return false;
            }

            if (String.IsNullOrWhiteSpace(loadTextBox.Text))
            {
                MessageBox.Show("Введите нагрузку!");
                return false;
            }

            return true;
        }

        private string AnyRemark()
        {
            if (String.IsNullOrWhiteSpace(remarkTextBox.Text)) return null;
            else return remarkTextBox.Text;
        }

        private void exercisesTypeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pathToExerciseFile = "ExercisesType/" + exercisesTypeListBox.SelectedItem + ".json";

            exercisesTypeListBox.Enabled = false;
        }

        private List<Exercise> GetListExercises()
        {
            var deserializableData = new List<Exercise>();

            if (FileProvider.TryGet(pathToExerciseFile, out var data))
            {
                data = FileProvider.GetData(pathToExerciseFile);
                deserializableData = JsonConvert.DeserializeObject<List<Exercise>>(data);
            }
            else FileProvider.Save(pathToExerciseFile, "[]");

            return deserializableData;

        }

        private void SaveExercise()
        {
            if (IsValid())
            {
                var exercise = new Exercise(textTextBox.Text,               // Название
                                            int.Parse(repeatTextBox.Text),  // Повторения
                                            loadTextBox.Text,               // Нагрузка
                                            AnyRemark());                   // Если введено примечание

                var list = GetListExercises();
                list.Add(exercise);
                var serializableList = JsonConvert.SerializeObject(list, Formatting.Indented);
                FileProvider.Save(pathToExerciseFile, serializableList);
            }

            exercisesTypeListBox.Enabled = true;
            textTextBox.Text   = null;
            repeatTextBox.Text = null; 
            loadTextBox.Text   = null;
            remarkTextBox.Text = null; 

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveExercise();
        }
    }
}
