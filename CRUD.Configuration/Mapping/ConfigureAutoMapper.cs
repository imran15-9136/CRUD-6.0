using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Models.Entity;
using Models.Request;

namespace CRUD.Configuration.Mapping
{
    public class ConfigureAutoMapper: Profile
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ConfigureAutoMapper));
        }

        public ConfigureAutoMapper()
        {
            CreateMap<ItemCategoryCreateDto, ItemCategory>();
        }
    }
}
