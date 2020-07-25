namespace TrainWindowsFormsApp
{
    public class Exercise
    {
        public string Text;              // Название упражнения
        public int Repeat;               // Количество повторенеий
        public int MaxRepeat;            // Максимально количество повторений, при достижении которого следует указать новую нагрузку
        public string Load;              // Нагрузка
        public string Remark;            // Примечания

        public Exercise(string text, int repeat, int maxRepeat, string load, string remark = null)
        {
            Text = text;
            Repeat = repeat;
            MaxRepeat = maxRepeat;
            Load = load;
            Remark = remark;
        }

        public Exercise() { }
    }
}
