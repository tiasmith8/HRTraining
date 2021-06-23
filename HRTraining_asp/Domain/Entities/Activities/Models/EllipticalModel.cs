using HRTraining_asp.Domain.Entities.Workouts;

namespace HRTraining_asp.Domain.Entities.Activities.Models
{
    public class EllipticalModel : ActivityModel
    {
        public int InclinePercentage { get; set; }
        public int Resistance { get; set; }
        public int StrokesPerMinute { get; set; }
        public bool BackwardDirection { get; set; }
    }
}
