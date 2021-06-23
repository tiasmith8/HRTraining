namespace HRTraining_asp.Domain.Entities.Activities.Models
{
    public class RunModel : ActivityModel
    {
        public int InclinePercentage { get; set; }
        public RouteModel Route { get; set; }
    }
}
