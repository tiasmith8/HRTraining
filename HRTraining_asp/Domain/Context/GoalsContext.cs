using HRTraining.Domain.Entities.Goals;
using HRTraining.Domain.Entities.Targets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining.Domain.Context
{
    public class GoalsContext : DbContext/*, IDataContext*/
    {
        public DbSet<Goal> Goal { get; set; }

        public async Task/*<Guid>*/ CreateAsync(Goal goal)
        {
            Goal.Add(goal);
            await SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var goal = await Goal.FindAsync(id);
            Goal.Remove(goal);
            await SaveChangesAsync ();
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
            where T : Goal
        {
            var goal = await Goal.FindAsync(id);
            return (T)goal;
        }

        public IQueryable<T> Queryable<T>()
        {
            var goals = Goal;
            return (IQueryable<T>)goals;
        }

        public async Task UpdateAsync(Goal goal)
        {
            Goal.Update(goal);
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Calorie>();
            builder.Entity<Distance>();
            builder.Entity<Duration>();
            builder.Entity<Pace>();
            builder.Entity<Target>().ToTable("Target");
            builder.Entity<Goal>();

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Trusted_Connection=yes;Initial Catalog=HRTraining;");
        }
    }
}
