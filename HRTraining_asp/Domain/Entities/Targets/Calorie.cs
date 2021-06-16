namespace HRTraining.Domain.Entities.Targets
{
    public class Calorie : Target
    {
        /// <summary>
        /// Goal for number of calories to burn in a given week or lifetime or single workout
        /// </summary>
        public virtual int Calories { get; set; }
    }
}
