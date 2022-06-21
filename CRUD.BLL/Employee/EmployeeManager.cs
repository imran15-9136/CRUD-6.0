using CRUD.BLL.Abstraction.Employee;
using CRUD.BLL.Base;
using CRUD.Repository.Abstraction.Employee;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BLL.Employee
{
    public class EmployeeManager : Manager<Employees>, IEmployeeManager
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository):base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
    }
}
