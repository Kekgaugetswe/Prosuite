using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Contracts.Dtos.Requests
{
    public class RiskOwnerRequest :BaseRequest
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public long RoleId { get; set; }

    }
}
