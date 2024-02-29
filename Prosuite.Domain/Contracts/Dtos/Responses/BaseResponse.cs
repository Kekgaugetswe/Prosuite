using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Contracts.Dtos.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Messages = new List<MessageResponse>();
            StatusCode = 200;

        }
        public int StatusCode { get; set; }
        public List<MessageResponse> Messages { get; set; }
    }
}
