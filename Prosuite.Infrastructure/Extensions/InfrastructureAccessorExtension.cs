using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.FileIO;
using Prosuite.Domain.Contracts.Interfaces.Repositories;
using Prosuite.Domain.Contracts.Interfaces.Services.Infrastructure.Utils;
using Prosuite.Domain.Entities;
using Prosuite.Infrastructure.DbContexts;
using Prosuite.Infrastructure.Repositories;
using Prosuite.Infrastructure.Utils;
using Pomelo.EntityFrameworkCore.MySql;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Infrastructure.Extensions
{
    public static  class InfrastructureAccessorExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuraation)
        {
            services.AddDbContexts(configuraation);
            services.AddCommandRepositories();
            services.AddQueryRepositories();
            services.AddUtils();


            return services;
        }
        

        static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuraation)
        {

            services.AddDbContext<APIDbContext>(options => {
                string connectionString = configuraation.GetConnectionString("ApiConnection");
                options.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly("Prosuite.API"));
            });
            services.AddScoped<DbContext, APIDbContext>();

            return services;
        }
        static IServiceCollection AddCommandRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICommandRepository<Role>, CommandRepository<Role>>();
            services.AddTransient<ICommandRepository<RiskOwner>, CommandRepository<RiskOwner>>();

            return services;
        }

        static IServiceCollection AddQueryRepositories(this IServiceCollection services)
        {
            services.AddTransient<IQueryRepository<Role>, QueryRepository<Role>>();
            services.AddTransient<IQueryRepository<RiskOwner>, RiskQueryRepository>();

            return services;
        }

        static IServiceCollection AddUtils(this IServiceCollection services)
        {
            
            services.AddTransient<IJsonSerializationManager, JsonSerializationManager>();
            services.AddTransient<IRestClientManager, RestClientManager>();
            

            return services;
        }
    }
}
