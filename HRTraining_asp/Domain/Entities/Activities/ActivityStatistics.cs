using HRTraining.Domain.Entities.Activities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRTraining.Domain.Entities
{
    // Tracked at the single ActivityHistory level
    // This data pulled from device and stored in a session record? - use the ble service
    public class ActivityStatistics : EntityBase
    {
        public virtual int AverageHeartRate { get; set; }
        public virtual int MaximumHeartRate { get; set; }
        public virtual int MinimumHeartRate { get; set; }
        public virtual int Calories { get; set; }
        public virtual double TotalDistance { get; set; }
        public virtual double AveragePace { get; set; }
        public virtual double Elevation { get; set; }
    }
}
