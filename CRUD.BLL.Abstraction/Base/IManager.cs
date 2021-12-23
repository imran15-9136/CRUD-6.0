using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BLL.Abstraction.Base
{
    public interface IManager<T> : IDisposable where T : class
    {
        Task<Result> AddAsync(T entity);
        Task<Result> UpdateAsync(T entity);
        Task<Result> RemoveAsync(int id);
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> GetAllAsyncPaginated(int pageIndex, int pageSize, string key, string searchString);
        Task<T> GetByIdAsync(int id);
        Task<T> GetFirstorDefault(int id);
    }
}
