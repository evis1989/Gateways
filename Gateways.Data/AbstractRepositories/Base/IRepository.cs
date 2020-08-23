using Gateways.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gateways.Data.AbstractRepositories.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);
        void AddRange(IEnumerable<T> items);
        Task<bool> UpdateAsync(T item);
        Task<bool> RemoveAsync(long? id);
        Task<T> GetByIdAsync(long? id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> AsQueryable();
        Task<bool> SaveChangesAsync();
    }
}
