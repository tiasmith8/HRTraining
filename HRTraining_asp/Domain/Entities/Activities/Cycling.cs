namespace HRTraining.Domain.Entities.Activities
{
    public class Cycling : Activity
    {
        public virtual int Rpm { get; set; }
        public virtual int Resistance { get; set; }
    }
}
