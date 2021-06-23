using HRTraining_asp.Domain.Entities.Goals;
using HRTraining_asp.Domain.Entities.Workouts;
using System;

namespace HRTraining_asp.Domain.Entities
{
    public class ProfileModel
    {
        public Guid? ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public DateTime Birthdate { get; set; }
        public int HeightInInches { get; set; }
        public int WeightInLbs { get; set; }

        public DeviceModel[] Devices { get; set; }
        public WorkoutHistoryModel[] WorkoutHistory { get; set; }
        public GoalModel[] Goals { get; set; }
        public WorkoutModel[] Workouts { get; set; }
    }
}
