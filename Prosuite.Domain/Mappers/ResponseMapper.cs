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
        

        public void MapResponses()
        {
            CreateMap<LookUpBase, LookUpResponse>().ReverseMap();
            CreateMap<Role, LookUpResponse>().ReverseMap();
            CreateMap<RiskOwner, RiskOwnerResponse>()

                .ForMember(dest => dest.Name, src => src.MapFrom(s=>s.Name))
                .ForMember(dest => dest.Title, src => src.MapFrom(s=>s.Title))
                .ForMember(dest => dest.Email, src => src.MapFrom(s=>s.Email))
                .ForMember(dest => dest.RoleId, src => src.MapFrom(s=>s.RoleId))
                .ForMember(dest => dest.Role, src => src.MapFrom(s=>s.Role.Name))
                ;

        }
    }
}