using CRUD.BLL.Abstraction.Category;
using CRUD.BLL.Abstraction.Items;
using CRUD.BLL.Category;
using CRUD.BLL.Items;
using CRUD.Configuration.Library;
using CRUD.Repository.Abstraction.Category;
using CRUD.Repository.Abstraction.Items;
using CRUD.Repository.Category;
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
        public static void Configuration(IServiceCollection services, IConfiguration configuration, string connection)
        {
            

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(EncryptProcess.DecryptString(connection)));

            

            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<IItemManager, ItemManager>();
            services.AddTransient<IItemRepository, ItemRepository>();

        }
    }
}
