using HRTraining.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining.Domain.Context
{
    public interface IDataContext
    {
        Task<T> GetByIdAsync<T>(Guid id);
        IQueryable<T> Queryable<T>();
        Task CreateAsync(Workout workout);
        Task UpdateAsync(Workout workout);
        Task DeleteByIdAsync(Guid id);
    }
}
