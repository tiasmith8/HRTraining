using HRTraining.Domain.Entities;
using ef = Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HRTraining.Domain.Entities.Activities;
using HRTraining.Domain.Entities.Targets;
using HRTraining.Domain.Entities.Workouts;
using HRTraining.Domain.Entities.Goals;

namespace HRTraining.Data
{
    public class DbContext : ef.DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Trusted_Connection=yes;Initial Catalog=HRTraining;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Profile>();

            builder.Entity<Device>();
            builder.Entity<Workout>();
            builder.Entity<WorkoutHistory>().HasMany(w => w.ActivityHistories);
            builder.Entity<Goal>();

            builder.Entity<Run>();
            builder.Entity<Walk>();
            builder.Entity<AerobicWorkout>();
            builder.Entity<Cooldown>();
            builder.Entity<Cycling>();
            builder.Entity<Run>();
            builder.Entity<Elliptical>();
            builder.Entity<Rebounder>();
            builder.Entity<Rest>();
            builder.Entity<Set>();
            builder.Entity<StrengthTraining>();
            builder.Entity<Stretch>();
            builder.Entity<Swim>();
            builder.Entity<Warmup>();
            builder.Entity<Activity>().ToTable("Activity");
            builder.Entity<Calorie>();
            builder.Entity<Distance>();
            builder.Entity<Duration>();
            builder.Entity<Target>().ToTable("Target");

            base.OnModelCreating(builder);
        }
    }
}
