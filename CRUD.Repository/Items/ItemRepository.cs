using CRUD.Repository.Abstraction.Items;
using CRUD.Repository.Base;
using Database.Database;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository.Items
{
    public class ItemRepository: Repository<Item>, IItemRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public ItemRepository(ApplicationDbContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
