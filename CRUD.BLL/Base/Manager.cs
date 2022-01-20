using CRUD.BLL.Abstraction.Base;
using CRUD.Repository.Abstraction.Base;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BLL.Base
{
    public class Manager<T>: IManager<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Manager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Dispose()
        {

        }

        public virtual async Task<Result> AddAsync(T entity)
        {
            bool isAdded = await _repository.AddAsync(entity);

            if (isAdded)
            {
                return Result.Success();
            }
            return Result.Failure(new[] { "Unable to save data!" });
        }

        public virtual Result Add(T entity)
        {
            bool isAdded = _repository.Add(entity);
            if (isAdded)
            {
                return Result.Success();
            }
            return Result.Failure(new[] { "Unable to save data!" });
        }

        public virtual async Task<Result> UpdateAsync(T entity)
        {
            bool isUpdate = await _repository.UpdateAsync(entity);

            if (isUpdate)
            {
                return Result.Success();
            }
            return Result.Failure(new[] { "Unable to update data!" });
        }

        public virtual async Task<Result> RemoveAsync(int id)
        {
            var data = await _repository.GetById(id);

            if (data != null)
            {
                bool isRemove = await _repository.RemoveAsync(data);
                if (isRemove)
                {
                    return Result.Success();
                }
            }
            return Result.Failure(new[] { "Unable to remove" });
        }

        public async virtual Task<ICollection<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetById(id);
        }

        public Task<T> GetFirstorDefault(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> GetAllAsyncPaginated(int pageIndex, int pageSize, string key, string searchString)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
