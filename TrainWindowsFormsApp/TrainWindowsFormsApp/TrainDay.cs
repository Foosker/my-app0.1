using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace TrainWindowsFormsApp
{
    public static class TrainDay
    {
        private static int progress;

        private static List<ExercisesType> upperBody = new List<ExercisesType>()
        {
            ExercisesType.D_Latissimus,
            ExercisesType.D_Chest,
            ExercisesType.D_DeltoidRear,
            ExercisesType.D_DeltoidMid,
            
            ExercisesType.O_Latissimus,
            ExercisesType.O_Chest,
            ExercisesType.O_DeltoidRear,
            ExercisesType.O_DeltoidMid
        };

        private static List<ExercisesType> lowerBody = new List<ExercisesType>()
        {
            ExercisesType.D_Quadriceps,
            ExercisesType.D_BicepsHip,
            ExercisesType.D_Calf,

            ExercisesType.O_Quadriceps,
            ExercisesType.O_BicepsHip,
            ExercisesType.O_Calf
        };

        private static List<ExercisesType> abs = new List<ExercisesType>()
        {
            ExercisesType.D_Abs,
            ExercisesType.D_ExtensorBack,

            ExercisesType.O_Abs,
            ExercisesType.O_ExtensorBack
        };

        private static List<ExercisesType> extraMuscles = new List<ExercisesType>()
        {
            ExercisesType.Trapezius,
            ExercisesType.DeltoidFront,

            ExercisesType.Biceps,
            ExercisesType.Triceps
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


            var count = abs.Count() / 2;
            var index = ChooseIndexMuscles(count);
            regularTrain.Add(abs[index]);

            count = lowerBody.Count() / 2;
            index = ChooseIndexMuscles(count);
            regularTrain.Add(lowerBody[index]);
            regularTrain.Add(lowerBody[index]);

            count = upperBody.Count() / 2;
            index = ChooseIndexMuscles(count);
            regularTrain.Insert(0, upperBody[index]);
            regularTrain.Insert(3, upperBody[index]);
            regularTrain.Insert(5, upperBody[index + count]);
            return regularTrain;
        }

        public static List<ExercisesType> GetAdditional(int progress)
        {
            var additionalTrain = new List<ExercisesType>();

            var count = abs.Count() / 2;
            var index = ChooseIndexMuscles(count);
            additionalTrain.Add(abs[index + count]);

            count = lowerBody.Count() / 2;
            index = ChooseIndexMuscles(count);
            additionalTrain.Add(lowerBody[index + count]);

            count = extraMuscles.Count() / 2;
            index = ChooseIndexMuscles(count);
            additionalTrain.Add(extraMuscles[index]);
            additionalTrain.Add(extraMuscles[index]);
            additionalTrain.Add(extraMuscles[index + count]);
            additionalTrain.Add(extraMuscles[index + count]);

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

