using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Contracts.Dtos.Responses
{
    public class ApiResponse
    {


        public int StatusCode { get; set; }
        public List<MessageResp> messages { get; set; }
        public List<string> data { get; set; }

    }
    public class MessageResp
    {
        public string Type { get; set; }
        public string Message { get; set; }

        public MessageResp()
        {
            Type = "";
            Message = string.Empty;
        }
    }
}
