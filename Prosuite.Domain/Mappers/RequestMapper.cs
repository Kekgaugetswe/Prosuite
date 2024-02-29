using Prosuite.Domain.Contracts.Dtos.Requests;
using Prosuite.Domain.Contracts.Dtos.Responses;
using Prosuite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Mappers
{
    public partial class ApiObjectMapping
    {
        public void MapRequests()
        {
            #region Lookups
            CreateMap<LookUpRequest, LookUpBase>();
            CreateMap<LookUpRequest, Role>();


            #endregion

            

            CreateMap<RiskOwnerRequest, RiskOwner>();
            
        }
    }
}
