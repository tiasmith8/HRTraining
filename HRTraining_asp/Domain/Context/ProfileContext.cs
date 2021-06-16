using HRTraining.Domain.Entities;
using HRTraining.Domain.Entities.Goals;
using HRTraining.Domain.Entities.Targets;
using HRTraining.Domain.Entities.Workouts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining.Domain.Context
{
    public class ProfileContext : DbContext
    {
        public DbSet<Profile> Profile { get; set; }

        public async Task CreateAsync(Profile profile)
        {
            Profile.Add(profile);
            await SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var profile = GetProfile(id);
            Profile.Remove(profile);
            await SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
            where T : Profile
        {
            var profile = GetProfile(id);
            return (T)profile;
        }

        public IQueryable<T> Queryable<T>()
            where T : Profile
        {
            var profiles = Profile.Include(p => p.Devices).Include(p => p.WorkoutHistory);
            return (IQueryable<T>)profiles;
        }

        public async Task UpdateAsync(Profile profile)
        {
            Profile.Update(profile);
            await SaveChangesAsync();
        }

        public async Task AddDeviceToProfile(Guid profileId, Device device)
        {
            var profile = GetProfile(profileId);
            profile.Devices.Add(device);
            await SaveChangesAsync();
        }

        public async Task AddGoalToProfile(Guid profileId, Goal goal)
        {
            var profile = GetProfile(profileId);
            profile.Goals.Add(goal);
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Profile>().ToTable("Profile");
            builder.Entity<Device>();
            builder.Entity<Calorie>();
            builder.Entity<Distance>();
            builder.Entity<Duration>();
            builder.Entity<Pace>();
            builder.Entity<Target>().ToTable("Target");
            builder.Entity<WorkoutHistory>();

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Trusted_Connection=yes;Initial Catalog=HRTraining;");
        }

        public Profile GetProfile(Guid id)
        {
            return Profile.Where(p => p.Id == id)
                .Include(p => p.Devices)
                .Include(p => p.WorkoutHistory)
                .Include(p => p.Goals)
                .FirstOrDefault();
        }
    }
}
