using System;

namespace HRTraining_asp.Domain.Entities.Targets.Models
{
    public class PaceModel : TargetModel
    {
        public TimeSpan Time { get; set; }
        public int Distance { get; set; }
    }
}
