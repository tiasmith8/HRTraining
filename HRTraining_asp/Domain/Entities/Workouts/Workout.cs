using HRTraining.Domain.Entities.Activities;
using HRTraining.Domain.Entities.Goals;
using HRTraining.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRTraining.Domain.Entities
{
    /// <summary>
    /// Workout Template should not hold statistics
    /// recipe
    /// </summary>
    public class Workout : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        [Required]
        public virtual List<Activity> Activities { get; set; }
        public virtual Goal Goal { get; set; }
    }
}
