using System.Collections.Generic;

namespace TrainWindowsFormsApp
{
    public static class TrainDay
    {
        public static int trainingOptions = 4;  // Количество дней тренировок
        public static List<bool> isBasicExercise = new List<bool>();

        private static List<ExercisesType> trainDay = new List<ExercisesType>();
        private static List<ExercisesType> warmUp = new List<ExercisesType>();

        private static List<ExercisesType> Back()
        {
            trainDay.Add(ExercisesType.AbsDinamic);
            trainDay.Add(ExercisesType.D_LatissimusBase);

            trainDay.Add(ExercisesType.O_LatissimusBase);

            trainDay.Add(ExercisesType.Calf);

            trainDay.Add(ExercisesType.O_LatissimusBase);

            trainDay.Add(ExercisesType.Calf);

            return trainDay;
        }

        private static List<ExercisesType> Chest()
        {
            trainDay.Add(ExercisesType.O_BicepsHip);

            trainDay.Add(ExercisesType.D_BicepsHip);
            trainDay.Add(ExercisesType.D_ChestBase);

            trainDay.Add(ExercisesType.ExtensorBack);
            trainDay.Add(ExercisesType.D_ChestBase);

            trainDay.Add(ExercisesType.O_ChestBase);

            return trainDay;
        }

        private static List<ExercisesType> RearShoulders()
        {
            trainDay.Add(ExercisesType.AbsStatic);
            trainDay.Add(ExercisesType.D_DeltoidRear);

            trainDay.Add(ExercisesType.O_DeltoidRear);

            trainDay.Add(ExercisesType.O_DeltoidRear);

            trainDay.Add(ExercisesType.Calf);

            trainDay.Add(ExercisesType.Calf);

            return trainDay;
        }

        private static List<ExercisesType> MiddleShoulders()
        {
            trainDay.Add(ExercisesType.O_Quadriceps);

            trainDay.Add(ExercisesType.D_Quadriceps);
            trainDay.Add(ExercisesType.D_DeltoidMid);

            trainDay.Add(ExercisesType.ExtensorBack);
            trainDay.Add(ExercisesType.D_DeltoidMid);

            trainDay.Add(ExercisesType.O_DeltoidMid);

            return trainDay;
        }

        public static List<ExercisesType> GetWarmUpList()
        {
            warmUp.Add(ExercisesType.CombatArms);
            warmUp.Add(ExercisesType.CombatArms);
            warmUp.Add(ExercisesType.CombatLegs);
            warmUp.Add(ExercisesType.CombatArms);
            warmUp.Add(ExercisesType.CombatArms);
            warmUp.Add(ExercisesType.CombatLegs);

            return warmUp;
        }

        public static List<ExercisesType> Get(int num)
        {
            var list = new List<ExercisesType>();

            switch (num)
            {
                case 1: list =        Back();     break;
                case 2: list =       Chest();     break;
                case 3: list =  RearShoulders();  break;
                case 0: list = MiddleShoulders(); break;
            }
            return list;
        }
    }
}

