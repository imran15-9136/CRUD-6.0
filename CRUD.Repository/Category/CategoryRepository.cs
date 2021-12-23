using CRUD.Repository.Abstraction.Category;
using CRUD.Repository.Base;
using Database.Database;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository.Category
{
    public class CategoryRepository:Repository<ItemCategory>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
