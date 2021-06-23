using HRTraining_asp.Domain.Entities.Targets.Models;
using System;

namespace HRTraining_asp.Domain.Entities.Goals
{
    public class GoalModel
    {
        public Guid? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TargetModel GoalTarget { get; set; }
        public virtual TimeSpan Duration { get; set; }
        public DateTime StartTime { get; set; }
        public int TargetValue { get; set; }
    }
}
