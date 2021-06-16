using HRTraining.Domain.Entities.Activities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRTraining.Domain.Entities.Runs
{
    /// <summary>
    /// Run up hill then down, repeat for determined number of times or distance.
    /// </summary>
    public class HillRun : Workout
    {
        public override string Name
        {
            get { return "Hill Run"; }
            set { }
        }

        public override string Description
        {
            get { return "Run up hill then down, repeat for determined number of times or distance."; }
            set { }
        }

        [NotMapped]
        public IList<Pace> UpTime { get; set; }
        [NotMapped]
        public IList<Pace> DownTime { get; set; }
    }
}
