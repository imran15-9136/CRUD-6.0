using CRUD.BLL.Abstraction.Base;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BLL.Abstraction.Employee
{
    public interface IEmployeeManager : IManager<Employees>
    {
    }
}
