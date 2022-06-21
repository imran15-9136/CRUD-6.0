using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository.Abstraction.Base
{
    public interface IRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        bool Add(T entity);
        Task<bool> UpdateAsync(T entity);
        bool Update(T entity);
        Task<bool> RemoveAsync(T entity);
        bool Remove(T entity);
        Task<ICollection<T>> GetAllAsync();
        List<T> GetAll();
        Task<T> GetFirstorDefault(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
        T GetById(int id);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        bool UpdateRange(IList<T> entity);
        Task<bool> UpdateRangeAsync(IList<T> entity);
        bool RemoveRange(IList<T> entity);
        Task<bool> RemoveRangeAsync(IList<T> entity);
        Task<bool> AddRangeAsync<T>(ICollection<T> entities) where T : class;
        IQueryable<T> GetAsNoTracking(Expression<Func<T, bool>> predicate);
        T GetFirstOrDefaultAsNoTracking(Expression<Func<T, bool>> predicate);
        Task<T> GetFirstOrDefaultAsNoTrackingAsync(Expression<Func<T, bool>> predicate);
    }
}
