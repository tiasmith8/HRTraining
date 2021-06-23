using HRTraining.Domain.Entities.Goals;
using System.Collections.Generic;

namespace HRTraining.Domain.Entities.Workouts
{
    public class WorkoutHistory : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public WorkoutHistory()
        {
            //Workout = workout;
            ActivityHistories = new List<ActivityHistory>();
        }

        //public virtual Workout Workout { get; set; }
        public virtual IList<ActivityHistory> ActivityHistories { get; set; }
        public virtual Goal Goal { get; set; }
        public virtual string Notes { get; set; }
    }
}
