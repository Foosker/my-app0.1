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
        static ExercisesType[] trainDay;

        private static ExercisesType[] First()

        {   // Грудь базовые, Бицуха бедра, Бицуха
            trainDay = new ExercisesType[3] { ExercisesType.ChestBase,
                                              ExercisesType.BicepsHip,
                                              ExercisesType.Biceps };

            return trainDay;
        }

        private static ExercisesType[] Second()
        {   // Широчайшие изолированные, Пресс динамические, Дельты средние
            trainDay = new ExercisesType[3] { ExercisesType.LatissimusIsol,
                                              ExercisesType.AbsDinamic,
                                              ExercisesType.DeltoidMid };


            return trainDay;
        }

        private static ExercisesType[] Third()
        {   // Квадры, Трапеции, Разгибатели спины
            trainDay = new ExercisesType[3] { ExercisesType.Quadriceps,
                                              ExercisesType.Trapezius,
                                              ExercisesType.ExtensorBack };


            return trainDay;
        }

        private static ExercisesType[] Fourth()
        {   // Грудь изолированные, Бицуха бедра, Трицепс
            trainDay = new ExercisesType[3] { ExercisesType.ChestIsol,
                                              ExercisesType.BicepsHip,
                                              ExercisesType.Triceps };


            return trainDay;
        }

        private static ExercisesType[] Fifth()
        {   // Широчайшие базовые, Пресс статические, Дельты задние
            trainDay = new ExercisesType[3] { ExercisesType.LatissimusBase,
                                              ExercisesType.AbsStatic,
                                              ExercisesType.DeltoidRear };



            return trainDay;
        }

        private static ExercisesType[] Sixth()
        {   // Квадры, Пердплечья, Разгибатели спины
            trainDay = new ExercisesType[3] { ExercisesType.Quadriceps,
                                              ExercisesType.Forearm,
                                              ExercisesType.ExtensorBack };



            return trainDay;
        }

        public static ExercisesType[] Get(int num)
        {
            var list = new ExercisesType[3];

            switch (num)
            {
                case (0): list = First();  break;
                case (1): list = Second(); break;
                case (2): list = Third();  break;
                case (3): list = Fourth(); break;
                case (4): list = Fifth();  break;
                case (5): list = Sixth();  break;
            }
            return list;
        }
    }
}

