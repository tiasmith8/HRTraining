namespace HRTraining.Domain.Entities.Activities
{
    public class Run : Activity
    {
        public int InclinePercentage { get; set; }
        public Route Route { get; set; }
    }
}
