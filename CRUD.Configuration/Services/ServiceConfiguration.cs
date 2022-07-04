using CRUD.BLL.Abstraction.Category;
using CRUD.BLL.Abstraction.Employee;
using CRUD.BLL.Abstraction.Items;
using CRUD.BLL.Abstraction.Report;
using CRUD.BLL.Category;
using CRUD.BLL.Employee;
using CRUD.BLL.Items;
using CRUD.BLL.Report;
using CRUD.Repository.Abstraction.Category;
using CRUD.Repository.Abstraction.Employee;
using CRUD.Repository.Abstraction.Items;
using CRUD.Repository.Category;
using CRUD.Repository.Employee;
using CRUD.Repository.Items;
using Database.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Configuration.Services
{
    public static class ServiceConfiguration
    {
        public static void Configuration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<IItemManager, ItemManager>();
            services.AddTransient<IItemRepository, ItemRepository>();

            services.AddTransient<IEmployeeManager, EmployeeManager>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<IEmployeeGroupManager, EmployeeGroupManager>();
            services.AddTransient<IEmployeeGroupRepository, EmployeeGroupRepository>();

            services.AddTransient<IReportService, ReportService>();

        }
    }
}
