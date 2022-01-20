using CRUD.Repository.Abstraction.Base;
using Database.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        ApplicationDbContext _db;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async virtual Task<bool> AddAsync(T entity)
        {
            _db.Add(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        public virtual bool Add(T entity)
        {
            _db.Add(entity);
            return _db.SaveChanges() > 0;
        }

        public async virtual Task<bool> UpdateAsync(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return await _db.SaveChangesAsync() > 0;
        }

        public async virtual Task<bool> RemoveAsync(T entity)
        {
            _db.Remove(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        public async virtual Task<ICollection<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public virtual List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public async virtual Task<T> GetFirstorDefault(Expression<Func<T, bool>> predicate)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async virtual Task<T> GetById(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Where(predicate).AsQueryable();
        }

        public virtual bool UpdateRange(IList<T> entity)
        {
            _db.Set<T>().UpdateRange(entity);
            return _db.SaveChanges() > 0;
        }
        public virtual async Task<bool> UpdateRangeAsync(IList<T> entity)
        {
            _db.Set<T>().UpdateRange(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        public bool RemoveRange(IList<T> entity)
        {
            _db.Set<T>().RemoveRange(entity);
            return _db.SaveChanges() > 0;
        }
        public async Task<bool> RemoveRangeAsync(IList<T> entity)
        {
            _db.Set<T>().RemoveRange(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddRangeAsync<T>(ICollection<T> entities) where T : class
        {
            await _db.AddRangeAsync(entities);
            return await _db.SaveChangesAsync() > 0;
        }

        public virtual IQueryable<T> GetAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().AsNoTracking().Where(predicate);
        }

        public virtual T GetFirstOrDefaultAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().AsNoTracking().FirstOrDefault(predicate);
        }

        public virtual async Task<T> GetFirstOrDefaultAsNoTrackingAsync(Expression<Func<T, bool>> predicate)
        {
            return await _db.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }
    }
}
