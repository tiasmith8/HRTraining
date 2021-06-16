namespace HRTraining.Domain.Entities.Runs
{
    /// <summary>
    /// Maintaining a comfortably hard or challenging pace; builds speed and teaches the body to run at a certain pace; usually run at a maximum of 80-85% HR
    /// </summary>
    public class TempoRun : Workout
    {
        public override string Name
        {
            get { return "Tempo Run"; }
            set { }
        }

        public override string Description
        {
            get { return "Maintaining a comfortably hard or challenging pace; builds speed and teaches the body to run at a certain pace; usually run at a maximum of 80-85% HR"; }
            set { }
        }
    }
}
