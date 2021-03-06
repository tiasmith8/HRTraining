using HRTraining.Domain.Entities.Goals;
using HRTraining.Domain.Entities.Workouts;
using System;
using System.Collections.Generic;

namespace HRTraining.Domain.Entities
{
    // Contains data about the user that is setup in the profile. Stores session data in list
    public class Profile : EntityBase
    {
        public Profile()
        {
            Devices = new List<Device>();
            WorkoutHistory = new List<WorkoutHistory>();
            Goals = new List<Goal>();
            Workouts = new List<Workout>();
        }

        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Location { get; set; }
        //public virtual Image Image { get; set; }
        //public virtual Image BackgroudImage { get; set; }
        public virtual DateTime Birthdate { get; set; }
        public virtual int HeightInInches { get; set; }
        public virtual int WeightInLbs { get; set; }

        public virtual IList<Device> Devices { get; set; }
        /// <summary>
        /// A workout turns into WorkoutHistory once the workout is started and then saved
        /// </summary>
        public virtual IList<WorkoutHistory> WorkoutHistory { get; set; }
        public virtual IList<Goal> Goals { get; set; }
        /// <summary>
        /// Preselectable workouts that the user has either created, or are shared in the db
        /// </summary>
        public virtual IList<Workout> Workouts { get; set; }
    }
}
