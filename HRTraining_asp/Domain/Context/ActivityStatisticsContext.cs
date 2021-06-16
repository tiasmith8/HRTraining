using HRTraining.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining.Domain.Context
{
    public class ActivityStatisticsContext : DbContext
    {
        public DbSet<ActivityStatistics> ActivityStatistics { get; set; }

        public async Task CreateAsync(ActivityStatistics activityStatistics)
        {
            ActivityStatistics.Add(activityStatistics);
            await SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var activityStatistics = await ActivityStatistics.FindAsync(id);
            ActivityStatistics.Remove(activityStatistics);
            await SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
            where T : ActivityStatistics
        {
            var activityStatistics = await ActivityStatistics.FindAsync(id);
            return (T)activityStatistics;
        }

        public IQueryable<T> Queryable<T>()
        {
            return (IQueryable<T>)ActivityStatistics.Find();
        }

        public async Task UpdateAsync(ActivityStatistics activityStatistics)
        {
            ActivityStatistics.Update(activityStatistics);
            await SaveChangesAsync();
        }
    }
}
