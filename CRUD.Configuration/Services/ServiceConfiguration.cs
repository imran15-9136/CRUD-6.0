﻿using CRUD.BLL.Abstraction.Category;
using CRUD.BLL.Category;
using CRUD.Repository.Abstraction.Category;
using CRUD.Repository.Category;
using Database.Database;
using Microsoft.EntityFrameworkCore;
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
        public static void Configuration(IServiceCollection services)
        {
            //    Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
            //Services.Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
        }
    }
}
