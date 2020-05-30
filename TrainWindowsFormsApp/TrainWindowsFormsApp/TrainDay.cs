using Aspose.Cells.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainWindowsFormsApp
{
    public static class TrainDay
    {
        static ExercisesType[] trainDay;

        public static ExercisesType[] First()
        {   // Грудь базовые, Квадры, Бицуха
            trainDay = new ExercisesType[3] { ExercisesType.ChestBase,
                                              ExercisesType.Quadriceps,
                                              ExercisesType.Biceps };

            return trainDay;
        }

        public static ExercisesType[] Second()
        {   // Широчайшие изолированные, Пресс динамические, Дельты средние
            trainDay = new ExercisesType[3] { ExercisesType.LatissimusIsol,
                                              ExercisesType.AbsDinamic,
                                              ExercisesType.DeltoidMid };


            return trainDay;
        }

        public static ExercisesType[] Third()
        {   // Бицуха бедра, Трапеции, Разгибатели спины
            trainDay = new ExercisesType[3] { ExercisesType.BicepsHip,
                                              ExercisesType.Trapezius,
                                              ExercisesType.ExtensorBack };


            return trainDay;
        }

        public static ExercisesType[] Fourth()
        {   // Грудь изолированные, Квадры, Трицепс
            trainDay = new ExercisesType[3] { ExercisesType.ChestIsol,
                                              ExercisesType.Quadriceps,
                                              ExercisesType.Triceps };


            return trainDay;
        }

        public static ExercisesType[] Fifth()
        {   // Широчайшие базовые, Пресс статические, Дельты задние
            trainDay = new ExercisesType[3] { ExercisesType.LatissimusBase,
                                              ExercisesType.AbsStatic,
                                              ExercisesType.DeltoidRear };



            return trainDay;
        }

        public static ExercisesType[] Sixth()
        {   // Бицуха бедра, Пердплечья, Разгибатели спины
            trainDay = new ExercisesType[3] { ExercisesType.BicepsHip,
                                              ExercisesType.Forearm,
                                              ExercisesType.ExtensorBack };



            return trainDay;
        }
    }
}

