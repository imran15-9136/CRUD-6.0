using CRUD.Repository.Abstraction.Employee;
using CRUD.Repository.Base;
using Database.Database;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository.Employee
{
    public class EmployeeRepository: Repository<Employees>, IEmployeeRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public EmployeeRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
    }
}
