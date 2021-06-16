namespace HRTraining
{
    // This is a subtype not enum. Have different properties
    // class hierarchy
    //public enum Activity
    //{
    //    Walk,
    //    Run,
    //    //Treadmill, - location
    //    Hike,
    //    Cycling,
    //    Elliptical,
    //    AerobicWorkout,
    //    Race,
    //    LongRun
    //}

    public enum DeviceManufacturer
    {
        AmazFit,
        FitBit
    }

    // class hierarchy
    // ShortGoal, WorkoutGoal, WeeklyGoal, LifeTimeGoal
    //public enum GoalType
    //{
    //    NumberOfWorkouts,
    //    Distance,
    //    Duration,
    //    Calorie
    //}

    public enum GoalStart
    {
        ThisWeek,
        NextWeek
    }

    public enum AudioStatistics
    {
        Time,
        Distance,
        AveragePace,
        CurrrentPace,
        AverageHeartRate,
        CurrentHeartRate
    }

    // UI - app sending info to you. not domain
    //public enum AudioTriggers
    //{
    //    Time,
    //    Distance,
    //    HeartRate,
    //}
}
