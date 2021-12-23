using CRUD.Repository.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
    }
}
