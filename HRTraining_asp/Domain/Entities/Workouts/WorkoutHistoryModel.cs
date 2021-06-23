using HRTraining_asp.Domain.Entities.Activities.Models;
using HRTraining_asp.Domain.Entities.Goals;
using System;

namespace HRTraining_asp.Domain.Entities.Workouts
{
    public class WorkoutHistoryModel
    {
        public Guid? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public WorkoutHistory()
        //{
        //    //Workout = workout;
        //    ActivityHistories = new List<ActivityHistory>();
        //}

        //public virtual Workout Workout { get; set; }
        public ActivityHistoryModel[] ActivityHistories { get; set; }
        public GoalModel Goal { get; set; }
        public string Notes { get; set; }
    }
}
