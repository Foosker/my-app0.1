using System.Collections.Generic;
using System.Linq;

namespace TrainWindowsFormsApp
{
    public static class TrainDay
    {
        private static int progress;

        private static List<ExercisesType>  mainMuscles = new List<ExercisesType>()
        {
            ExercisesType.D_Chest,
            ExercisesType.D_DeltoidMid,
            ExercisesType.D_Latissimus,
            ExercisesType.CombatLegs,

            ExercisesType.D_DeltoidRear,
            ExercisesType.Trapezius,
            ExercisesType.DeltoidFront,
            ExercisesType.CombatArms,

            ExercisesType.O_Chest,
            ExercisesType.O_DeltoidMid,
            ExercisesType.O_Latissimus,
            ExercisesType.CombatLegs,

            ExercisesType.Biceps,
            ExercisesType.O_DeltoidMid,
            ExercisesType.Triceps,
            ExercisesType.CombatArms
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

            var index = ChooseIndexMuscles(lowerBody.Count() / 2);
            regularTrain.Add(lowerBody[index]);
            regularTrain.Add(lowerBody[index]);

            var count = mainMuscles.Count() / 4;
            index = ChooseIndexMuscles(count);
            regularTrain.Insert(0, mainMuscles[index]);
            regularTrain.Insert(1, mainMuscles[index + count]);
            regularTrain.Insert(3, mainMuscles[index]);
            regularTrain.Insert(4, mainMuscles[index + count]);
            regularTrain.Add(mainMuscles[index + count * 3]);
            regularTrain.Add(mainMuscles[index + count * 3]);

            return regularTrain;
        }

        public static List<ExercisesType> GetAdditional()
        {
            var additionalTrain = new List<ExercisesType>();

            var count = lowerBody.Count() / 2;
            var index = ChooseIndexMuscles(count);
            additionalTrain.Add(lowerBody[index + count]);
            additionalTrain.Add(lowerBody[index + count]);

            count = mainMuscles.Count() / 4;
            index = ChooseIndexMuscles(count);
            additionalTrain.Insert(1, mainMuscles[index + count * 2]);
            additionalTrain.Add(mainMuscles[index + count * 3]);

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

