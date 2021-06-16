using HRTraining.Domain.Entities.Targets;
using System;
using System.Collections.Generic;

namespace HRTraining.Domain.Entities
{
    /// <summary>
    /// Snapshot of workout at the time when you did it - momento pattern
    /// Also contains statistics for each activity in the workout
    /// + when and where it happened
    /// </summary>
    public class ActivityHistory /*: Activity*/
    {
        public ActivityHistory(DateTime? startTime = null)
        {
            //StartTime = startTime == null ? DateTime.UtcNow : startTime;
            StartTime = !startTime.HasValue ? DateTime.UtcNow : startTime;
        }

        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Instructions { get; set; }
        public virtual IList<Target> Targets { get; set; }
        public virtual TimeSpan Duration { get; set; }



        public virtual DateTime? StartTime { get; set; }

        /// <summary>
        /// Contains heart rate statistics
        /// </summary>
        public IList<ActivityStatistics> ActivityStatistics { get; set; }
    }
}
