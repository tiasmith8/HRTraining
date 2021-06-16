using System;

namespace HRTraining.Domain.Entities.Activities
{
    public class Pace
    {
        public virtual int MileNumber { get; set; }
        public virtual TimeSpan Duration { get; set; }
        public virtual double Distance { get; set; }
    }
}
