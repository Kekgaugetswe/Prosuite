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
    public interface IBaseService<T, Response, Request, Filter>
     where T : Entity where Response : class where Request : BaseRequest where Filter : FilterableRequest
    {

        Task<DataResponse<Response>> Create(Request request);




        PagedResponse<Response> Find(Filter request);


        Task<DataResponse<Response>> Get(long id);



        Task<DataResponse<List<Response>>> All();

        Task<DataResponse<Response>> Update(Request request);

        Task<BaseResponse> Delete(long id);
    }
}
