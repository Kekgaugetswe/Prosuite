using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Contracts.Dtos.Responses
{
    public class DataResponse<T> : BaseResponse where T : class
    {
        public T Data { get; set; }
    }
}
