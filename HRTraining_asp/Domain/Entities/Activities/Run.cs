namespace HRTraining.Domain.Entities.Activities
{
    public class Run : Activity
    {
        public virtual int InclinePercentage { get; set; }
        public virtual Route Route { get; set; }
    }
}
