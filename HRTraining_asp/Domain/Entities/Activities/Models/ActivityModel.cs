using HRTraining_asp.Domain.Entities.Targets.Models;
using System;

namespace HRTraining_asp.Domain.Entities.Activities.Models
{
    public class ActivityModel
    {
        public Guid? ID { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public TargetModel[] Targets { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
