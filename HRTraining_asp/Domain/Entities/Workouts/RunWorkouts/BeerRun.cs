namespace HRTraining.Domain.Entities.Runs
{
    /// <summary>
    /// A race that consists of one beer (12 oz, minimum of 5% alcohol by volume) consumed every ¼ mile. Penalty laps are given for vomiting.
    /// </summary>    
    public class BeerRun : Workout
    {
        public override string Name
        {
            get { return "Beer Run"; }
            set { }
        }

        public override string Description
        {
            get { return "A race that consists of one beer (12 oz, minimum of 5% alcohol by volume) consumed every ¼ mile. Penalty laps are given for vomiting."; }
            set { }
        }

        /// <summary>
        /// Name of the beer consumed
        /// </summary>
        public string BeerName { get; set; }

    }
}
