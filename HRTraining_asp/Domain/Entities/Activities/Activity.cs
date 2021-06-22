using HRTraining.Domain.Entities.Targets;
using System;
using System.Collections.Generic;

namespace HRTraining.Domain.Entities.Activities
{
    [Serializable]
    // Stretch, Run, Walk - everything
    public abstract class Activity : EntityBase
    {
        public virtual string Name { get; set; }
        // public virtual TimeSpan Duration { get; set; }
        public virtual string Instructions { get; set; }
        public virtual IList<Target> Targets { get; set; }


        // newly added for unit test. Took out previously?
        // Need to be able to set a length of time to do the warm-up/activity
        // as part of the template/recipe
        public virtual TimeSpan Duration { get; set; }
    }
}
