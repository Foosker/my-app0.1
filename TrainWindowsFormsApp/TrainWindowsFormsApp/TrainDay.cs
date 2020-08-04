using System.Collections.Generic;

namespace TrainWindowsFormsApp
{
    public static class TrainDay
    {
        public static int trainingOptions = 6;  // Количество дней тренировок
        public static List<bool> isBasicExercise = new List<bool>();

        static List<ExercisesType> trainDay = new List<ExercisesType>();


        private static List<ExercisesType> BackAndTriceps()
        {
            trainDay.Add(ExercisesType.D_LatissimusBase);
            trainDay.Add(ExercisesType.D_LatissimusIsol);

            trainDay.Add(ExercisesType.O_LatissimusBase);

            trainDay.Add(ExercisesType.O_LatissimusIsol);

            trainDay.Add(ExercisesType.DeltoidFront);

            trainDay.Add(ExercisesType.Triceps);

            return trainDay;
        }

        private static List<ExercisesType> Legs1()
        {
            trainDay.Add(ExercisesType.O_Quadriceps);

            trainDay.Add(ExercisesType.D_Quadriceps);
            trainDay.Add(ExercisesType.D_BicepsHip);

            trainDay.Add(ExercisesType.O_BicepsHip);

            trainDay.Add(ExercisesType.Calf);

            trainDay.Add(ExercisesType.Calf);

            return trainDay;
        }

        private static List<ExercisesType> CortexAndShoulders1()
        {
            trainDay.Add(ExercisesType.D_DeltoidRear);
            trainDay.Add(ExercisesType.ExtensorBack);

            trainDay.Add(ExercisesType.O_DeltoidRear);

            trainDay.Add(ExercisesType.D_Trapezius);
            trainDay.Add(ExercisesType.ExtensorBack);

            trainDay.Add(ExercisesType.O_Trapezius);

            return trainDay;
        }

        private static List<ExercisesType> ChestAndBiceps()
        {
            trainDay.Add(ExercisesType.D_ChestBase);
            trainDay.Add(ExercisesType.D_ChestIsol);

            trainDay.Add(ExercisesType.O_ChestBase);

            trainDay.Add(ExercisesType.O_ChestIsol);

            trainDay.Add(ExercisesType.Biceps);

            trainDay.Add(ExercisesType.Biceps);

            return trainDay;
        }

        private static List<ExercisesType> Legs2()
        {
            trainDay.Add(ExercisesType.O_BicepsHip);

            trainDay.Add(ExercisesType.D_BicepsHip);
            trainDay.Add(ExercisesType.D_Quadriceps);

            trainDay.Add(ExercisesType.O_Quadriceps);

            trainDay.Add(ExercisesType.Calf);

            trainDay.Add(ExercisesType.Calf);

            return trainDay;
        }

        private static List<ExercisesType> CortexAndShoulders2()
        {
            trainDay.Add(ExercisesType.D_DeltoidMid);
            trainDay.Add(ExercisesType.AbsDinamic);

            trainDay.Add(ExercisesType.O_DeltoidMid);

            trainDay.Add(ExercisesType.D_Trapezius);
            trainDay.Add(ExercisesType.AbsStatic);

            trainDay.Add(ExercisesType.O_Trapezius);

            return trainDay;
        }

        public static List<ExercisesType> Get(int num)
        {
            var list = new List<ExercisesType>();

            switch (num)
            {
                case 1: list =   BackAndTriceps();    break;
                case 2: list =       Legs1();         break;
                case 3: list = CortexAndShoulders1(); break;
                case 4: list =   ChestAndBiceps();    break;
                case 5: list =       Legs2();         break;
                case 0: list = CortexAndShoulders2(); break;
            }
            return list;
        }
    }
}

