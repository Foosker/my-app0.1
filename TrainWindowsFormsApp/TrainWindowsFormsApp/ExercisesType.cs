namespace TrainWindowsFormsApp
{
    public enum ExercisesType
    {
        // Упражнения для разминки
        CombatArms,
        CombatLegs,

        // Двустороние упражнения
        D_Trapezius,
        D_DeltoidFront,
        D_DeltoidMid,
        D_DeltoidRear,
        D_Chest,
        D_Latissimus,
        D_Legs,
        D_Core,
        D_BackExtensor,

        // Одностороние
        O_Trapezius,
        O_DeltoidFront,
        O_DeltoidMid,
        O_DeltoidRear,
        O_Chest, 
        O_Latissimus,
        O_Legs,
        O_Core,
        O_BackExtensor,

        // Лёгкие упражнения
        Scapula,
        Shin,
        Triceps,
        Neck,
        Forearm,
        Calf,
        HipBiceps,
        Biceps
    }

    public static class RusExerciseType
    {
        public static string[] list = new string[28]
        {
            "Удар рукой",
            "Удар ногой",

            "Трапеции",
            "Пер. дельты",
            "Ср. дельты",
            "Зад. дельты",
            "Грудь",
            "Широчайшие",
            "Квадрицепсы",
            "Пресс",
            "Разгиб. спины",

            "Трапеции",
            "Пер. дельты",
            "Ср. дельты",
            "Зад. дельты",
            "Грудь",
            "Широчайшие",
            "Квадрицепсы",
            "Пресс",
            "Разгиб. спины",

            "Лопатки",
            "Голень",
            "Трицепс",
            "Шея",
            "Предплечья",
            "Икроножные",
            "Бицепс бедра",
            "Бицепс руки"
        };
    }
}
