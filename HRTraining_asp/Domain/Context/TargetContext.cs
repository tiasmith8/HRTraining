using HRTraining.Domain.Entities.Targets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining.Domain.Context
{
    public class TargetContext : DbContext
    {
        public DbSet<Target> Targets { get; set; }

        public DbSet<Calorie> Calorie { get; set; }
        public DbSet<Distance> Distance { get; set; }
        public DbSet<Duration> Duration { get; set; }
        public DbSet<Pace> Pace { get; set; }

        public async Task CreateAsync(Target target)
        {
            Targets.Add(target);
            await SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var target = await Targets.FindAsync(id);
            Targets.Remove(target);
            await SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
            where T : Target
        {
            var target = await Targets.FindAsync(id);
            return (T)target;
        }

        public IQueryable<T> Queryable<T>()
        {
            return (IQueryable<T>)Targets.Find();
        }

        public async Task UpdateAsync(Target target)
        {
            Targets.Update(target);
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
