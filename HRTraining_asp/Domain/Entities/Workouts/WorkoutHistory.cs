using HRTraining.Domain.Entities.Activities;
using HRTraining.Domain.Entities.Goals;
using System;
using System.Collections.Generic;

namespace HRTraining.Domain.Entities.Workouts
{
    public class WorkoutHistory /*: Workout*/
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        //public WorkoutHistory(Workout workout)
        //{
        //    Workout = workout;
        //    ActivityHistories = (IList<ActivityHistory>)workout.Activities;
        //}

        //public WorkoutHistory()
        //{

        //}

        //public virtual Workout Workout { get; set; }
        public virtual IList<ActivityHistory> ActivityHistories { get; set; }
        public virtual Goal Goal { get; set; }
        public virtual string Notes { get; set; }
    }
}
