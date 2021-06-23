namespace HRTraining.Domain.Entities.Activities
{
    public class Elliptical : Activity
    {
        public virtual int InclinePercentage { get; set; }
        public virtual int Resistance { get; set; }
        public virtual int StrokesPerMinute { get; set; }
        public virtual bool BackwardDirection { get; set; }
    }
}
