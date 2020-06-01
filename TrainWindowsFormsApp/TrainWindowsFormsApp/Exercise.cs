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
        public string Text { get; set; }    // Название упражнения
        public int Repeat { get; set; }     // Количество повторенеий
        public string Load;                 // Нагрузка
        public string Remark;               // Примечания

        public Exercise(string text, int repeat, string load, string remark = null)
        {
            Text = text;
            Repeat = repeat;
            Load = load;
            Remark = remark;
        }

        public Exercise() { }
    }
}
