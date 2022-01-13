using CRUD.BLL.Abstraction.Items;
using CRUD.BLL.Base;
using CRUD.Repository.Abstraction.Items;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BLL.Items
{
    public class ItemManager: Manager<Item>, IItemManager
    {
        private readonly IItemRepository _repository;
        public ItemManager(IItemRepository repository):base(repository)
        {
            _repository = repository;
        }
    }
}
