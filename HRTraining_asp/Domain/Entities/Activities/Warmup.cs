using System.Collections.Generic;

namespace HRTraining.Domain.Entities.Activities
{
    public class Warmup : Activity
    {
        public virtual IList<Activity> Activities { get; set; }
    }
}
