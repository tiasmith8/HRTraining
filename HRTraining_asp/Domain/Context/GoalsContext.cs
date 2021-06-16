using HRTraining.Domain.Entities;
using HRTraining.Domain.Entities.Goals;
using HRTraining.Domain.Entities.Targets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining.Domain.Context
{
    public class GoalsContext : DbContext
    {
        public DbSet<Goal> Goal { get; set; }

        private ProfileContext _profileContext;

        public GoalsContext(ProfileContext profileContext)
        {
            _profileContext = profileContext;
        }

        public async Task<Guid> CreateAsync(Goal goal, Guid id = default(Guid))
        {
            if(id != Guid.Empty)
            {
                var profile = await _profileContext.GetByIdAsync<Profile>(id);
                profile.Goals.Add(goal);
                await SaveChangesAsync();
                return goal.Id;
            }

            Goal.Add(goal);
            await SaveChangesAsync();
            return goal.Id;
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

        public IQueryable<T> Queryable<T>(Guid id = default(Guid))
        {
            if(id != Guid.Empty)  
            {
                var profile = _profileContext.GetByIdAsync<Profile>(id).Result;
                return (IQueryable<T>)profile.Goals;
            }

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
