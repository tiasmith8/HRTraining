using HRTraining.Domain.Entities;
using HRTraining.Domain.Entities.Activities;
using HRTraining.Domain.Entities.Goals;
using HRTraining.Domain.Entities.Runs;
using HRTraining.Domain.Entities.Targets;
using HRTraining.Domain.Entities.Workouts;
using Microsoft.EntityFrameworkCore;

namespace HRTraining.Data
{
    public class HRTrainingContext : DbContext
    {
        public DbSet<Goal> Goal { get; set; }

        // Activities - 17
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivityHistory> ActivityHistory { get; set; }
        public DbSet<ActivityStatistics> ActivityStatistics { get; set; }
        public DbSet<AerobicWorkout> AerobicWorkout { get; set; }
        public DbSet<Cooldown> Cooldown { get; set; }
        public DbSet<Cycling> Cycling { get; set; }
        public DbSet<Elliptical> Elliptical { get; set; }
        public DbSet<Hike> Hike { get; set; }
        public DbSet<Rebounder> Rebounder { get; set; }
        public DbSet<Rest> Rest { get; set; }
        public DbSet<Run> Run { get; set; }
        public DbSet<Set> Set { get; set; }
        public DbSet<StrengthTraining> StrengthTraining { get; set; }
        public DbSet<Stretch> Stretch { get; set; }
        public DbSet<Swim> Swim { get; set; }
        public DbSet<Walk> Walk { get; set; }
        public DbSet<Warmup> Warmup { get; set; }

        // Targets
        public DbSet<Calorie> Calorie { get; set; }
        public DbSet<Distance> Distance { get; set; }
        public DbSet<Duration> Duration { get; set; }
        public DbSet<Domain.Entities.Targets.Pace> Pace { get; set; }
        public DbSet<Target> Target { get; set; }

        // Workouts
        public DbSet<Workout> Workout { get; set; }
        public DbSet<WorkoutHistory> WorkoutHistory { get; set; }

        // RunWorkouts - Templates - 5 concrete, 1 abstract
        public DbSet<BeerRun> BeerRun { get; set; }
        public DbSet<CustomRun> CustomRun { get; set; }
        public DbSet<HillRun> HillRun { get; set; }
        public DbSet<RecoveryRun> RecoveryRun { get; set; }
        public DbSet<TempoRun> TempoRun { get; set; }

        // Entities not in a folder
        public DbSet<Account> Account { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Route> Route { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Trusted_Connection=yes;Initial Catalog=HRTraining;");
        }
    }
}
