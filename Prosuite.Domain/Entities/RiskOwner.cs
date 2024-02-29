using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Entities
{
    public class RiskOwner : Entity
    {
        public string Name { get; set; }
        public string? Title { get; set; }
        public long RoleId { get; set; }
        public string Email { get; set; }
        public Role? Role { get; set; }
    }
}
