namespace HRTraining.Domain.Entities.Targets
{
    // Possibly rename the targets since they're in the namespace
    public class Distance : Target
    {
        public virtual double DistanceMileage { get; set; }
    }
}
