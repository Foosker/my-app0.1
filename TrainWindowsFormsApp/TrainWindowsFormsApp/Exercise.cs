using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainWindowsFormsApp
{
    public class Exercise
    {   
        public string text { get; }         // Название упражнения
        public int repeat { get; set; }     // Количество повторенеий
        public bool status { get; set; }    // Выполнены все повторения или нет
        public string load;                 // Нагрузка
        public string remark;               // Примечания

        static Random random = new Random();

        public Exercise()
        {
            string Text = text;
            int Repeat = repeat;
            bool Status = status;
            string Load = load;
            string Remark = remark;
        }

        public Exercise[] GetTrainDay(int trainNumber)
        {
            var exerciseList = new Exercise[9];
            var exerciseTypes = TrainDay.Get(trainNumber % 6);  // Получаем массив с видами упражнений
            for (int i = 0; i < exerciseTypes.Length; i++)
            {
                var pathExerciseFile = "ExercisesType/" + exerciseTypes[i].ToString() + ".json"; // Название упражнения преобразуем в путь к файлу,
                var data = FileProvider.GetData(pathExerciseFile);                               // получили данные из файла
                var deserializableData = JsonConvert.DeserializeObject<List<Exercise>>(data);    // и десериализовали в список.

                var index = i; // По этому значению будет присваиваться индекс упражнения в исходный массив
                for (int j = 0; j < 3; j++)
                {
                    var randomExercise = deserializableData[random.Next(deserializableData.Count)]; // Выбираем случайное упражнение,
                    deserializableData.Remove(randomExercise);                                      // удаляем его из списка,
                    exerciseList[index] = randomExercise;                                           // вставляем его в исходный массив.
                    index += 3;  // Учеличивается по принципу: индекс 0-3-6, 1-4-7, 2-5-8.
                }
            }
            return exerciseList;
        }
    }
}
