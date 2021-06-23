using HRTraining.Domain.Entities.Activities;
using System.Collections.Generic;

namespace HRTraining.Domain.Entities.Runs
{
    public class CustomRun : Workout
    {
        public override string Name
        {
            get { return "Beer Run"; }
            set { }
        }

        public override string Description
        {
            get { return "A race that consists of one beer (12 oz, minimum of 5% alcohol by volume) consumed every ¼ mile. Penalty laps are given for vomiting."; }
            set { }
        }

        //public IList<Activity> Activities { get; set; }
    }
}
