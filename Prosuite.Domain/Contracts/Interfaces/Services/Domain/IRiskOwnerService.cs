using Prosuite.Domain.Contracts.Dtos.Requests;
using Prosuite.Domain.Contracts.Dtos.Responses;
using Prosuite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Contracts.Interfaces.Services.Domain
{
    public interface IRiskOwnerService : IBaseService<RiskOwner, RiskOwnerResponse, RiskOwnerRequest, FilterableRequest>
    {
    }
}


