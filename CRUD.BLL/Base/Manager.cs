using CRUD.BLL.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BLL.Base
{
    public class Manager<T>: IManager<T> where T : class
    {
    }
}
