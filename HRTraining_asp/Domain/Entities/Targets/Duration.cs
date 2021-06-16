namespace HRTraining.Domain.Entities.Targets
{
    public class Duration : Target
    {
        public virtual int Hours { get; set; }
        public virtual int Minutes { get; set; }
    }
}
