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
    public class RiskOwnerService : BaseService<RiskOwner, RiskOwnerResponse, RiskOwnerRequest, FilterableRequest>, IRiskOwnerService
    {
        public RiskOwnerService(IValidatorBase<RiskOwnerRequest> validator, IMapper mapper, ICommandRepository<RiskOwner> commandRepository, IQueryRepository<RiskOwner> queryRepository, IJsonSerializationManager serializer, ILogger<BaseService<RiskOwner, RiskOwnerResponse, RiskOwnerRequest, FilterableRequest>> logger) : base(validator, mapper, commandRepository, queryRepository, serializer, logger)
        {
        }

        protected override IQueryable<RiskOwner> FindLogic(FilterableRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
