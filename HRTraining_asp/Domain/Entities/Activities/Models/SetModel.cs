namespace HRTraining_asp.Domain.Entities.Activities.Models
{
    public class SetModel : ActivityModel
    {
        public int NumberOfRepeats { get; set; }
        public ActivityModel WorkInterval { get; set; }
        public ActivityModel RecoveryInterval { get; set; }
    }
}
