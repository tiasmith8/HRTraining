using HRTraining.Domain.Entities;
using HRTraining.Domain.Entities.Activities;
using HRTraining.Domain.Entities.Goals;
using HRTraining.Domain.Entities.Targets;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Activity = HRTraining.Domain.Entities.Activities.Activity;
using Pace = HRTraining.Domain.Entities.Targets.Pace;

namespace HRTraining.Domain.Context
{
    public class WorkoutContext : DbContext
    {
        public DbSet<Workout> Workout { get; set; }

        public async Task<Guid> CreateAsync(Workout workout)
        {
            Workout.Add(workout);
            await SaveChangesAsync();
            return workout.Id;
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var workout = await Workout.FindAsync(id);
            Workout.Remove(workout);
            await SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
            where T : Workout
        {
            var workout = await Workout.FindAsync(id);
            return (T)workout;
        }

        public IQueryable<T> Queryable<T>()
        {
            return (IQueryable<T>)Workout;
        }

        public async Task UpdateAsync(Workout workout)
        {
            Workout.Update(workout);
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Goal>();
            builder.Entity<Workout>().ToTable("Workout");
            builder.Entity<Run>();
            builder.Entity<Walk>();
            builder.Entity<AerobicWorkout>();
            builder.Entity<Cooldown>();
            builder.Entity<Cycling>();
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
            builder.Entity<Pace>();
            builder.Entity<Target>().ToTable("Target");
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Trusted_Connection=yes;Initial Catalog=HRTraining;");
        }
    }
}
