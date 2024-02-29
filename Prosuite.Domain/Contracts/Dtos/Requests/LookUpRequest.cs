using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Contracts.Dtos.Requests
{
    public class LookUpRequest :BaseRequest
    {
        public string Name { get; set; }
    }
}
