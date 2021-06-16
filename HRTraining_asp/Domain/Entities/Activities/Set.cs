namespace HRTraining.Domain.Entities.Activities
{
    public class Set : Activity
    {
        public virtual int NumberOfRepeats { get; set; }
        public virtual Activity WorkInterval { get; set; }
        public virtual Activity RecoveryInterval { get; set; }
    }
}
