using System.Collections.Generic;
using System.Linq;

namespace TrainWindowsFormsApp
{
    public static class TrainDay
    {
        private static int progress;
        public static List<int> indentBetweenExercises;

        private static int count;

        private static List<ExercisesType>  mainMuscles = new List<ExercisesType>()
        {
            ExercisesType.D_Chest,
            ExercisesType.D_Latissimus,
            ExercisesType.D_DeltoidFront,
            ExercisesType.D_DeltoidMid,

            ExercisesType.D_Chest,
            ExercisesType.D_Latissimus,
            ExercisesType.D_Trapezius,
            ExercisesType.D_DeltoidRear,


            ExercisesType.O_Chest,
            ExercisesType.O_Latissimus,
            ExercisesType.O_DeltoidFront,
            ExercisesType.O_DeltoidMid,
            
            ExercisesType.O_Chest,
            ExercisesType.O_Latissimus,
            ExercisesType.O_Trapezius,
            ExercisesType.O_DeltoidRear,
        };

        private static List<ExercisesType> lowerMuscles = new List<ExercisesType>()
        {
            ExercisesType.D_Legs,
            ExercisesType.D_Core,
            ExercisesType.D_BackExtensor,


            ExercisesType.O_Legs,
            ExercisesType.O_Core,
            ExercisesType.O_BackExtensor,
        };

        private static List<ExercisesType> otherMuscles = new List<ExercisesType>()
        {
            ExercisesType.Scapula,
            ExercisesType.Shin,
            ExercisesType.Triceps,
            ExercisesType.Neck,
            ExercisesType.Forearm,
            ExercisesType.Calf,
            ExercisesType.HipBiceps,
            ExercisesType.Biceps,
        };

        private static int ChooseIndexMuscles()
        {
            var num = progress % count;
            return num;
        }

        public static List<ExercisesType> GetTrain(int _progress)
        {
            indentBetweenExercises = new List<int>() { 2, 4};

            progress = _progress;

            var regularTrain = new List<ExercisesType>();

            count = mainMuscles.Count() / 2;
            var index = ChooseIndexMuscles();
            regularTrain.Add(mainMuscles[index]);
            regularTrain.Add(mainMuscles[index]);
            regularTrain.Add(mainMuscles[index + count]);

            count = lowerMuscles.Count() / 2;
            index = ChooseIndexMuscles();
            regularTrain.Insert(1, lowerMuscles[index]);
            regularTrain.Insert(3, lowerMuscles[index]);

            return regularTrain;
        }

        public static List<ExercisesType> GetAdditional()
        {
            indentBetweenExercises = new List<int>() { 1, 2, 3, 4};

            var additionalTrain = new List<ExercisesType>();

            count = mainMuscles.Count() / 2;
            var index = ChooseIndexMuscles();
            additionalTrain.Add(mainMuscles[index + count]);
            additionalTrain.Add(mainMuscles[index + count]);

            count = lowerMuscles.Count() / 2;
            index = ChooseIndexMuscles();
            additionalTrain.Insert(0, lowerMuscles[index + count]);
            additionalTrain.Insert(2, lowerMuscles[index + count]);

            return additionalTrain;
        }

        public static List<ExercisesType> GetWarmUpList()
        {
            var warmUp = new List<ExercisesType>()
            {
                ExercisesType.CombatArms,
                ExercisesType.CombatArms,
                ExercisesType.CombatLegs,
                ExercisesType.CombatArms,
                ExercisesType.CombatArms,
                ExercisesType.CombatLegs
            };
            return warmUp;
        }
    }
}

