using Microsoft.AspNetCore.Mvc;
using Prosuite.Domain.Contracts.Dtos.Requests;
using Prosuite.Domain.Contracts.Dtos.Responses;
using Prosuite.Domain.Contracts.Interfaces.Services.Domain;
using Prosuite.Domain.Entities;

namespace Prosuite.API.Controllers
{
    public class RiskOwnerController : EntityController<RiskOwner, RiskOwnerResponse, RiskOwnerRequest, FilterableRequest>
    {
        IRiskOwnerService service;
        public RiskOwnerController(IRiskOwnerService service) : base(service)
        {
            this.service = service;
        }

       
    }
}
