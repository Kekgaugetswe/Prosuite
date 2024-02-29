using AutoMapper;
using Microsoft.Extensions.Logging;
using Prosuite.Domain.Contracts.Dtos.Requests;
using Prosuite.Domain.Contracts.Dtos.Responses;
using Prosuite.Domain.Contracts.Interfaces.Repositories;
using Prosuite.Domain.Contracts.Interfaces.Services.Domain;
using Prosuite.Domain.Contracts.Interfaces.Services.Infrastructure.Utils;
using Prosuite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Services
{
    public class LookUpService<T> : BaseService<T, LookUpResponse, LookUpRequest, FilterableRequest>, ILookUpService<T> where T : LookUpBase
    {
        public LookUpService(
            IValidatorBase<LookUpRequest> validator,
            ICommandRepository<T> commandRepository,
            IQueryRepository<T> queryRepository,
            IJsonSerializationManager serializer,
            ILogger<BaseService<T, LookUpResponse, LookUpRequest, FilterableRequest>> logger,
            IMapper mapper) : base( validator, mapper, commandRepository, queryRepository, serializer, logger)
        {
        }

        protected override IQueryable<T> FindLogic(FilterableRequest request)
        {
            return !string.IsNullOrEmpty(request.Search) ? _queryRepository.Filter(l =>
                 l.Name.ToLower().Contains(request.Search.ToLower()) && l.IsActive == true)
                 :
                 _queryRepository.Filter(l => l.IsActive == true);
        }
    }
}
