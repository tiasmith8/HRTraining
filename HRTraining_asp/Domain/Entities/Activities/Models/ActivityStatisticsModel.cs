using System;

namespace HRTraining_asp.Domain.Entities.Activities.Models
{
    public class ActivityStatisticsModel
    {
        public Guid? ID { get; set; }
        public int AverageHeartRate { get; set; }
        public int MaximumHeartRate { get; set; }
        public int MinimumHeartRate { get; set; }
        public int Calories { get; set; }
        public double TotalDistance { get; set; }
        public double AveragePace { get; set; }
        public double Elevation { get; set; }
    }
}
