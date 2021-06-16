namespace HRTraining.Domain.Entities.Activities
{
    public class Elliptical : Activity
    {
        public int InclinePercentage { get; set; }
        public int Resistance { get; set; }
        public int StrokesPerMinute { get; set; }
        public bool BackwardDirection { get; set; }
    }
}
