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
    public class EmployeeGroupManager : Manager<EmployeeGroup>, IEmployeeGroupManager
    {
        private readonly IEmployeeGroupRepository employeeGroupRepository;
        public EmployeeGroupManager(IEmployeeGroupRepository employeeGroupRepository) :base(employeeGroupRepository)
        {
            this.employeeGroupRepository = employeeGroupRepository;
        }
    }
}
