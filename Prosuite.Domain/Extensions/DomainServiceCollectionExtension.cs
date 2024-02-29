using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Prosuite.Domain.Contracts.Dtos.Requests;
using Prosuite.Domain.Contracts.Interfaces.Services.Domain;
using Prosuite.Domain.Entities;
using Prosuite.Domain.Mappers;
using Prosuite.Domain.Services;
using Prosuite.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Extensions
{
    public static class DomainServiceCollectionExtension
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddServices();
            services.AddValidators();
            services.AddMappers();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            
            services.AddTransient<ILookUpService<Role>,LookUpService<Role>>();
            services.AddTransient<IRiskOwnerService, RiskOwnerService>();



            return services;
        }

        static IServiceCollection AddValidators(this IServiceCollection services)
        {

            services.AddTransient<IValidatorBase<LookUpRequest>, ValidatorBase<LookUpRequest>>();
            services.AddTransient<IValidatorBase<RiskOwnerRequest>, ValidatorBase<RiskOwnerRequest>>();
           
            return services;
        }

        private static IServiceCollection AddMappers(this IServiceCollection services)
        {

            var mapConfig = new MapperConfiguration(config => config.AddProfile(new ApiObjectMapping()));
            IMapper mapper = mapConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
