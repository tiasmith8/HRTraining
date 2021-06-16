using HRTraining.Domain.Context;
using HRTraining.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining.Domain.Context
{
    public class AccountContext : DbContext/*, IDataContext*/
    {
        public DbSet<Account> Accounts { get; set; }

        public async Task CreateAsync(Account account)
        {
            await Accounts.AddAsync(account);
            await SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var account = await Accounts.FindAsync(id);
            Accounts.Remove(account);
            await SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
            where T : Account
        {
            var account = await Accounts.FindAsync(id);
            return (T)account;
        }

        public IQueryable<T> Queryable<T>()
        {
            var accounts = Accounts.Find();
            return (IQueryable<T>)accounts;
        }

        public async Task UpdateAsync(Account account)
        {
            Accounts.Update(account);
            SaveChanges();
        }
    }
}
