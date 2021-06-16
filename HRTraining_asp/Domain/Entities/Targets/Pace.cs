using HRTraining.Domain.Entities.Goals;
using System;

namespace HRTraining.Domain.Entities.Targets
{
    public class Pace : Target
    {
        // Ex: 6 minute mile
        //public double Pace { get; set; }
        public TimeSpan Time { get; set; }
        public int Distance { get; set; }
    }
}
