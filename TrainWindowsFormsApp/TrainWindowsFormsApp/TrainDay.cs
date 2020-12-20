using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace TrainWindowsFormsApp
{
    public static class TrainDay
    {
        private static int progress;
        public static List<int> indentBetweenExercises;

        private static int count;


        private static List<ExercisesType> startMuscles = new List<ExercisesType>()
        {
            ExercisesType.Triceps,
            ExercisesType.Biceps,
            ExercisesType.O_Legs,
        };

        private static List<ExercisesType>  mainMuscles = new List<ExercisesType>()
        {
            ExercisesType.D_Chest,
            ExercisesType.D_Latissimus,
            ExercisesType.D_Legs,

            ExercisesType.O_Chest,
            ExercisesType.O_Latissimus,
            ExercisesType.O_Legs,
        };

        private static List<ExercisesType> otherMuscles = new List<ExercisesType>()
        {
            ExercisesType.D_DeltoidFront,
            ExercisesType.D_DeltoidMid,
            ExercisesType.Neck,

            ExercisesType.D_Trapezius,
            ExercisesType.D_DeltoidRear,
            ExercisesType.Neck,

            ExercisesType.O_DeltoidFront,
            ExercisesType.O_DeltoidMid,
            ExercisesType.Neck,

            ExercisesType.O_Trapezius,
            ExercisesType.O_DeltoidRear,
            ExercisesType.Neck,
        };

        private static List<ExercisesType> extraMuscles = new List<ExercisesType>()
        {
            ExercisesType.D_Calf,
            ExercisesType.D_Core,
            ExercisesType.Forearm,

            ExercisesType.O_Calf,
            ExercisesType.O_Core,
            ExercisesType.Forearm,
        };

        private static int ChooseIndexMuscles()
        {
            var num = progress % count;
            return num;
        }

        public static List<ExercisesType> GetTrain(int _progress)
        {
            indentBetweenExercises = new List<int>() { 1, 4};

            progress = _progress;

            var regularTrain = new List<ExercisesType>();

            count = startMuscles.Count();
            var index = ChooseIndexMuscles();
            regularTrain.Add(startMuscles[index]);

            regularTrain.Add(mainMuscles[index]);

            regularTrain.Add(extraMuscles[index]);

            count = otherMuscles.Count() / 2;
            index = ChooseIndexMuscles();
            regularTrain.Insert(3, otherMuscles[index]);

            return regularTrain;
        }

        public static List<ExercisesType> GetAdditional()
        {
            indentBetweenExercises = new List<int>() { 1, 2, 3, 4};

            var additionalTrain = new List<ExercisesType>();

            count = startMuscles.Count();
            var index = ChooseIndexMuscles();
            additionalTrain.Add(startMuscles[index]);

            additionalTrain.Add(extraMuscles[index + count]);

            additionalTrain.Add(mainMuscles[index + count]);

            additionalTrain.Add(extraMuscles[index + count]);

            count = otherMuscles.Count() / 2;
            index = ChooseIndexMuscles();

            additionalTrain.Add(otherMuscles[index]);

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

