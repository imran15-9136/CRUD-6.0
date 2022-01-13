using CRUD.Repository.Abstraction.Items;
using CRUD.Repository.Base;
using Database.Database;
using Microsoft.EntityFrameworkCore;
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

        public async override Task<Item> GetById(int id)
        {
            return await _dbcontext.Items.FromSqlRaw<Item>("SP_GetItemById {0}", id).FirstOrDefaultAsync();
        }
    }
}
