using HRTraining.Domain.Entities;
using HRTraining.Domain.Entities.Targets;
using HRTraining.Domain.Entities.Workouts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining.Domain.Context
{
    public class WorkoutHistoryContext : DbContext
    {   
        public DbSet<WorkoutHistory> WorkoutHistory { get; set; }

        public async Task CreateAsync(WorkoutHistory workoutHistory)
        {
            WorkoutHistory.Add(workoutHistory);
            await SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var workoutHistory = await WorkoutHistory.FindAsync(id);
            WorkoutHistory.Remove(workoutHistory);
            await SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
            where T : WorkoutHistory
        {
            var workoutHistory = await WorkoutHistory.FindAsync(id);
            return (T)workoutHistory;
        }

        public IQueryable<T> Queryable<T>(Guid id)
        {
            return (IQueryable<T>)WorkoutHistory;
        }

        public async Task UpdateAsync(WorkoutHistory workoutHistory)
        {
            WorkoutHistory.Update(workoutHistory);
            await SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Trusted_Connection=yes;Initial Catalog=HRTraining;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Calorie>();
            builder.Entity<Distance>();
            builder.Entity<Duration>();
            builder.Entity<Pace>();
            builder.Entity<Target>().ToTable("Target");
            base.OnModelCreating(builder);
        }
    }
}
