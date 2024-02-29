using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Contracts.Dtos.Requests
{
    public class FilterableRequest : BaseRequest
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string Search { get; set; }
    }
}
