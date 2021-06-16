using HRTraining.Domain.Entities.Activities;
using HRTraining.Domain.Entities.Targets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Activity = HRTraining.Domain.Entities.Activities.Activity;
using Pace = HRTraining.Domain.Entities.Targets.Pace;

namespace HRTraining.Domain.Context
{
    public class ActivityContext : DbContext
    {
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Run> Run { get; set; }
        public DbSet<AerobicWorkout> AerobicWorkout { get; set; }
        public DbSet<Cooldown> Cooldown { get; set; }
        public DbSet<Cycling> Cycling { get; set; }
        public DbSet<Elliptical> Elliptical { get; set; }
        public DbSet<Hike> Hike { get; set; }
        public DbSet<Rebounder> Rebounder { get; set; }
        public DbSet<Rest> Rest { get; set; }
        public DbSet<Set> Set { get; set; }
        public DbSet<StrengthTraining> StrengthTraining { get; set; }
        public DbSet<Stretch> Stretch { get; set; }
        public DbSet<Swim> Swim { get; set; }
        public DbSet<Walk> Walk { get; set; }
        public DbSet<Warmup> Warmup { get; set; }

        public async Task CreateAsync(Activity activity)
        {
            Activity.Add(activity);
            await SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var activity = await Activity.FindAsync(id);
            Activity.Remove(activity);
            await SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
            where T : Activity
        {
            var activity = Activity.Where(a => a.Id == id).Include(a => a.Targets);
            return (T)activity;
        }

        public IQueryable<T> Queryable<T>()
            where T : Activity
        {
            var activities = Activity
                //.Include(a => a.Targets)
                ;
            return (IQueryable<T>)activities;
        }

        public async Task UpdateAsync(Activity activity)
        {
            Activity.Update(activity);
            await SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Trusted_Connection=yes;Initial Catalog=HRTraining;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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
            builder.Entity<Pace>();
            builder.Entity<Target>().ToTable("Target");
            base.OnModelCreating(builder);
        }
    }
}
