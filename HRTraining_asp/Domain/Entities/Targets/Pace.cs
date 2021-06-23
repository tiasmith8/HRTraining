using System;

namespace HRTraining.Domain.Entities.Targets
{
    public class Pace : Target
    {
        // Ex: 6 minute mile
        //public double Pace { get; set; }
        public virtual TimeSpan Time { get; set; }
        public virtual int Distance { get; set; }
    }
}
