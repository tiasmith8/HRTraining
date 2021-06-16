using HRTraining.Domain.Entities.Targets;
using System;

namespace HRTraining.Domain.Entities.Goals
{
    // Weekly goals, workout goal, weightloss goal, blood pressure goal, 6min mile
    public class Goal
    {
        public virtual Guid Id { get; set; }
        /// <summary>
        /// Ex: 3-minute Plank
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// Description of what the user plans to accomplish
        /// Example: Hold a three minute plank
        /// </summary>
        public virtual string Description { get; set; }

        // Calorie Target / Distance Target / Duration Target / Pace Target
        public virtual Target GoalTarget { get; set; }

        /// <summary>
        /// How long you have to accomplish the goal
        /// This can be week, month, days, lifetime
        /// The application sets the duration based on start time
        /// </summary>
        public virtual TimeSpan Duration { get; set; }
        public virtual DateTime StartTime { get; set; }

        // This can be number of workouts, rpms, resistance on a stationary bike. This is for targets not predefined.
        public virtual int TargetValue { get; set; }
    }
}
