using Prosuite.Domain.Contracts.Dtos.Requests;
using Prosuite.Domain.Contracts.Dtos.Responses;
using Prosuite.Domain.Entities;

namespace Prosuite.Domain.Contracts.Interfaces.Services.Domain
{
    public interface ILookUpService<T> : IBaseService<T, LookUpResponse, LookUpRequest, FilterableRequest>  where T : LookUpBase
    {
    }
}
