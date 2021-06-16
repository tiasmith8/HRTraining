using HRTraining.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining.Domain.Context
{
    public class ActivityHistoryContext : DbContext
    {
        public DbSet<ActivityHistory> ActivityHistories { get; set; }

        public async Task CreateAsync(ActivityHistory activityHistory)
        {
            ActivityHistories.Add(activityHistory);
            await SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var activityHistory = await ActivityHistories.FindAsync(id);
            ActivityHistories.Remove(activityHistory);
            await SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
            where T : ActivityHistory
        {
            var activityHistory = await ActivityHistories.FindAsync(id);
            return (T)activityHistory;
        }

        public IQueryable<T> Queryable<T>()
        {
            return (IQueryable<T>)ActivityHistories.Find();
        }

        public async Task UpdateAsync(ActivityHistory activityHistory)
        {
            ActivityHistories.Update(activityHistory);
            await SaveChangesAsync();
        }
    }
}
