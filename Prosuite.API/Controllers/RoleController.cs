using Microsoft.AspNetCore.Mvc;
using Prosuite.Domain.Contracts.Interfaces.Services.Domain;
using Prosuite.Domain.Entities;

namespace Prosuite.API.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : LookUpBaseController<Role>
    {
        public RoleController(ILookUpService<Role> service) : base(service)
        {
        }
    }
}
