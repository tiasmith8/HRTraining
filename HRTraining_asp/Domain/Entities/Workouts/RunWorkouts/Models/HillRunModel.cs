using HRTraining_asp.Domain.Entities.Targets.Models;

namespace HRTraining_asp.Domain.Entities.Workouts.RunWorkouts.Models
{
    public class HillRunModel : WorkoutModel
    {
        public PaceModel[] UpTime { get; set; }
        public PaceModel[] DownTime { get; set; }
    }
}
