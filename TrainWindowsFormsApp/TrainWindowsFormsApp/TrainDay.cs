using System.Collections.Generic;
using System.Linq;

namespace TrainWindowsFormsApp
{
    public static class TrainDay
    {
        private static int progress;

        private static List<ExercisesType>  mainMuscles = new List<ExercisesType>()
        {
            ExercisesType.D_Latissimus,
            ExercisesType.D_Chest,
            ExercisesType.D_DeltoidMid,
            ExercisesType.CombatLegs,

            ExercisesType.D_DeltoidRear,
            ExercisesType.D_DeltoidFront,
            ExercisesType.D_Trapezius,
            ExercisesType.CombatArms
        };

        private static List<ExercisesType> extraMuscles = new List<ExercisesType>()
        {
            ExercisesType.O_DeltoidRear,
            ExercisesType.O_DeltoidFront,
            ExercisesType.Biceps,
            ExercisesType.CombatArms,

            ExercisesType.Biceps,
            ExercisesType.O_Chest,
            ExercisesType.O_Trapezius,
            ExercisesType.Triceps,

            ExercisesType.O_Latissimus,
            ExercisesType.Triceps,
            ExercisesType.O_DeltoidMid,
            ExercisesType.CombatLegs
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

        private static int ChooseIndexMuscles(int count)
        {
            var num = progress % count;
            return num;
        }

        public static List<ExercisesType> GetTrain(int _progress)
        {
            progress = _progress;

            var regularTrain = new List<ExercisesType>();

            var count = lowerBody.Count() / 2;
            var index = ChooseIndexMuscles(count);
            regularTrain.Add(lowerBody[index + count]);
            regularTrain.Add(lowerBody[index]);
            regularTrain.Add(lowerBody[index]);

            count = mainMuscles.Count() / 2;
            index = ChooseIndexMuscles(count);
            regularTrain.Insert(1, mainMuscles[index]);
            regularTrain.Insert(2, mainMuscles[index + count]);
            regularTrain.Insert(4, mainMuscles[index]);
            regularTrain.Insert(5, mainMuscles[index + count]);

            index = ChooseIndexMuscles(extraMuscles.Count());
            regularTrain.Add(extraMuscles[index]);

            return regularTrain;
        }

        public static List<ExercisesType> GetAdditional()
        {
            var additionalTrain = new List<ExercisesType>();

            var count = extraMuscles.Count() / 3;
            var index = ChooseIndexMuscles(count);
            additionalTrain.Add(extraMuscles[index]);
            additionalTrain.Add(extraMuscles[index + count]);
            additionalTrain.Add(extraMuscles[index + count * 2]);

            count = lowerBody.Count() / 2;
            index = ChooseIndexMuscles(count);
            additionalTrain.Insert(1, lowerBody[index + count]);
            additionalTrain.Insert(3, lowerBody[index + count]);

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

