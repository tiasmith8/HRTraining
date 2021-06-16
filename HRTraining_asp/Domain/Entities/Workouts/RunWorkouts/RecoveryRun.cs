namespace HRTraining.Domain.Entities.Runs
{
    /// <summary>
    /// An easy steady pace for enjoyment or recovery; improves aerobic conditioning; intensity should permit conversation and be no more than 60-70% maximum HR
    /// </summary>
    public class RecoveryRun : Workout
    {
        public override string Name
        {
            get { return "Recovery Run"; }
            set { }
        }

        public override string Description
        {
            get { return "An easy steady pace for enjoyment or recovery. It improves aerobic conditioning. The intensity should permit conversation and be no more than 60-70% maximum HR"; }
            set { }
        }
    }
}
