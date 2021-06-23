using HRTraining_asp.Domain.Entities.Activities.Models;
using HRTraining_asp.Domain.Entities.Goals;
using System;

namespace HRTraining_asp.Domain.Entities.Workouts
{
    public class WorkoutModel
    {
        public Guid? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ActivityModel[] Activities { get; set; }
        public GoalModel Goal { get; set; }
    }
}
