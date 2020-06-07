using Aspose.Cells.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Json;
using System.Security.Cryptography;

namespace TrainWindowsFormsApp
{
    public static class TrainDay
    {
        public static int trainingOptions = 4;

        static List<ExercisesType> trainDay = new List<ExercisesType>();

        private static List<ExercisesType> First()
        {
            trainDay.Add(ExercisesType.ChestBase);
            trainDay.Add(ExercisesType.DeltoidRear);

            trainDay.Add(ExercisesType.ChestBase);
            trainDay.Add(ExercisesType.DeltoidRear);

            trainDay.Add(ExercisesType.ChestIsol);
            trainDay.Add(ExercisesType.Triceps);

            return trainDay;
        }

        private static List<ExercisesType> Second()
        {
            trainDay.Add(ExercisesType.Quadriceps);
            trainDay.Add(ExercisesType.ExtensorBack);

            trainDay.Add(ExercisesType.Quadriceps);
            trainDay.Add(ExercisesType.ExtensorBack);

            trainDay.Add(ExercisesType.Trapezius);
            trainDay.Add(ExercisesType.Trapezius);

            return trainDay;
        }

        private static List<ExercisesType> Third()
        {
            trainDay.Add(ExercisesType.LatissimusBase);
            trainDay.Add(ExercisesType.DeltoidMid);

            trainDay.Add(ExercisesType.LatissimusBase);
            trainDay.Add(ExercisesType.DeltoidMid);

            trainDay.Add(ExercisesType.LatissimusIsol);
            trainDay.Add(ExercisesType.Biceps);

            return trainDay;
        }

        private static List<ExercisesType> Fourth()
        {
            trainDay.Add(ExercisesType.BicepsHip);
            trainDay.Add(ExercisesType.AbsDinamic);

            trainDay.Add(ExercisesType.BicepsHip);
            trainDay.Add(ExercisesType.AbsDinamic);

            trainDay.Add(ExercisesType.Forearm);
            trainDay.Add(ExercisesType.AbsStatic);

            return trainDay;
        }

        public static List<ExercisesType> Get(int num)
        {
            var list = new List<ExercisesType>();

            switch (num)
            {
                case (0): list = First();   break;
                case (1): list = Second();  break;
                case (2): list = Third();   break;
                case (3): list = Fourth();  break;
            }
            return list;
        }
    }
}

