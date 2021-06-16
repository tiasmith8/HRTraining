using System.Collections.Generic;

namespace HRTraining.Domain.Entities.Activities
{
    public class Cooldown : Activity
    {
        public virtual IList<Activity> Activities { get; set; }
    }
}
