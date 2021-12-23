using CRUD.BLL.Abstraction.Category;
using CRUD.BLL.Base;
using CRUD.Repository.Abstraction.Base;
using CRUD.Repository.Abstraction.Category;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BLL.Category
{
    public class CategoryManager : Manager<ItemCategory>, ICategoryManager
    {
        private readonly ICategoryRepository _repository;
        public CategoryManager(ICategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
