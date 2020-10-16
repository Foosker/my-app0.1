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

        private static List<ExercisesType>  mainMuscles = new List<ExercisesType>()
        {
            ExercisesType.D_Latissimus,
            ExercisesType.CombatArms,
            ExercisesType.D_Chest,
            ExercisesType.CombatLegs,
        };

        private static List<ExercisesType> otherMuscles = new List<ExercisesType>()
        {
            ExercisesType.D_Trapezius,
            ExercisesType.CombatLegs,
            ExercisesType.D_DeltoidRear,
            ExercisesType.CombatArms,

            ExercisesType.D_DeltoidFront,
            ExercisesType.CombatLegs,
            ExercisesType.D_DeltoidMid,
            ExercisesType.CombatArms,
        };

        private static List<ExercisesType> extraMuscles = new List<ExercisesType>()
        {

            ExercisesType.Triceps,
            ExercisesType.Forearm,
            ExercisesType.Biceps,
            ExercisesType.Neck,

            ExercisesType.O_DeltoidFront,
            ExercisesType.Forearm,
            ExercisesType.O_DeltoidMid,
            ExercisesType.Neck,

            ExercisesType.O_Trapezius,
            ExercisesType.Forearm,
            ExercisesType.O_DeltoidRear,
            ExercisesType.Neck,

            ExercisesType.O_Latissimus,
            ExercisesType.Forearm,
            ExercisesType.O_Chest,
            ExercisesType.Neck
        };

        private static List<ExercisesType> lowerBody = new List<ExercisesType>()
        {
            ExercisesType.D_Legs,
            ExercisesType.D_Core,
            ExercisesType.D_Calf,

            ExercisesType.O_Legs,
            ExercisesType.O_Core,
            ExercisesType.O_Calf
        };

        private static int ChooseIndexMuscles()
        {
            var num = progress % count;
            return num;
        }

        public static List<ExercisesType> GetTrain(int _progress)
        {
            indentBetweenExercises = new List<int>() { 1, 4, 7, 8};

            progress = _progress;

            var regularTrain = new List<ExercisesType>();

            count = lowerBody.Count() / 2;
            var index = ChooseIndexMuscles();
            regularTrain.Add(lowerBody[index + count]);
            regularTrain.Add(lowerBody[index]);
            regularTrain.Add(lowerBody[index]);

            count = mainMuscles.Count();
            index = ChooseIndexMuscles();
            regularTrain.Insert(1, mainMuscles[index]);
            regularTrain.Insert(4, mainMuscles[index]);

            count = otherMuscles.Count();
            index = ChooseIndexMuscles();
            regularTrain.Insert(2, otherMuscles[index]);
            regularTrain.Insert(5, otherMuscles[index]);

            count = extraMuscles.Count();
            index = ChooseIndexMuscles();
            regularTrain.Add(extraMuscles[index]);
            regularTrain.Add(extraMuscles[index % 4]);

            return regularTrain;
        }

        public static List<ExercisesType> GetAdditional()
        {
            indentBetweenExercises = new List<int>() { 1, 2, 3, 4 };

            var additionalTrain = new List<ExercisesType>();

            count = lowerBody.Count() / 2;
            var index = ChooseIndexMuscles();
            additionalTrain.Add(lowerBody[index + count]);
            additionalTrain.Add(lowerBody[index + count]);

            count = otherMuscles.Count();
            index = ChooseIndexMuscles();
            additionalTrain.Insert(1, otherMuscles[index]);

            count = extraMuscles.Count();
            index = ChooseIndexMuscles();
            additionalTrain.Add(extraMuscles[index]);

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

