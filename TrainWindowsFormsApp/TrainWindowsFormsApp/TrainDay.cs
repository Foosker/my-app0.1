using System.Collections.Generic;

namespace TrainWindowsFormsApp
{
    public static class TrainDay
    {
        public static int trainingOptions = 7;  // Количество дней тренировок

        static List<ExercisesType> trainDay = new List<ExercisesType>();

        private static List<ExercisesType> Shoulders()
        {
            trainDay.Add(ExercisesType.DeltoidRear);
            trainDay.Add(ExercisesType.DeltoidMid);
            trainDay.Add(ExercisesType.DeltoidMid);
            trainDay.Add(ExercisesType.DeltoidFront);
            trainDay.Add(ExercisesType.Trapezius);
            trainDay.Add(ExercisesType.Trapezius);

            return trainDay;
        }

        private static List<ExercisesType> ChestAndBiceps()
        {
            trainDay.Add(ExercisesType.ChestIsol);
            trainDay.Add(ExercisesType.ChestBase);
            trainDay.Add(ExercisesType.ChestIsol);
            trainDay.Add(ExercisesType.ChestBase);
            trainDay.Add(ExercisesType.Biceps);
            trainDay.Add(ExercisesType.Biceps);

            return trainDay;
        }

        private static List<ExercisesType> BackAndTriceps()
        {
            trainDay.Add(ExercisesType.LatissimusIsol);
            trainDay.Add(ExercisesType.LatissimusBase);
            trainDay.Add(ExercisesType.LatissimusIsol);
            trainDay.Add(ExercisesType.LatissimusBase);
            trainDay.Add(ExercisesType.Triceps);
            trainDay.Add(ExercisesType.Triceps);

            return trainDay;
        }

        private static List<ExercisesType> Legs()
        {
            trainDay.Add(ExercisesType.Quadriceps);
            trainDay.Add(ExercisesType.Quadriceps);
            trainDay.Add(ExercisesType.BicepsHip);
            trainDay.Add(ExercisesType.BicepsHip);
            trainDay.Add(ExercisesType.Calf);
            trainDay.Add(ExercisesType.Calf);

            return trainDay;
        }

        private static List<ExercisesType> Cortex()
        {
            trainDay.Add(ExercisesType.AbsDinamic);
            trainDay.Add(ExercisesType.AbsDinamic);
            trainDay.Add(ExercisesType.AbsStatic);
            trainDay.Add(ExercisesType.AbsStatic);
            trainDay.Add(ExercisesType.ExtensorBack);
            trainDay.Add(ExercisesType.ExtensorBack);

            return trainDay;
        }

        public static List<ExercisesType> Get(int num)
        {
            var list = new List<ExercisesType>();

            switch (num)
            {
                case 1: list = BackAndTriceps();    break;
                case 2: list =      Legs();         break;
                case 3: list =     Cortex();        break;
                case 4: list = ChestAndBiceps();    break;
                case 5: list =      Legs();         break;
                case 6: list =    Shoulders();      break;
                case 0: list =     Cortex();        break;
            }
            return list;
        }
    }
}

