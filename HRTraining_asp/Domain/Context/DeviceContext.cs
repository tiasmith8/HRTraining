using HRTraining.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining.Domain.Context
{
    public class DeviceContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }

        public async Task CreateAsync(Device device)
        {
            Devices.Add(device);
            await SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var device = await Devices.FindAsync(id);
            Devices.Remove(device);
            await SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
            where T : Device
        {
            var device = await Devices.FindAsync(id);
            return (T)device;
        }

        public IQueryable<T> Queryable<T>(Guid id)
        {
            return (IQueryable<T>)Devices;
        }

        public async Task UpdateAsync(Device device)
        {
            Devices.Update(device);
            await SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Trusted_Connection=yes;Initial Catalog=HRTraining;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Device>().ToTable("Device");
            base.OnModelCreating(builder);
        }
    }
}
