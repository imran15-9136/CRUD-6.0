using CRUD.Repository.Abstraction.Base;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository.Abstraction.Items
{
    public interface IItemRepository: IRepository<Item>
    {
    }
}
