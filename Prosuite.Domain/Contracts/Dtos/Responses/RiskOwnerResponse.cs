using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Contracts.Dtos.Responses
{
    public class RiskOwnerResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public long RoleId { get; set; }
        public string Role {  get; set; }
    }
}
