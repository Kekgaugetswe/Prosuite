using Microsoft.EntityFrameworkCore;
using Prosuite.Domain.Contracts.Interfaces.Repositories;
using Prosuite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Infrastructure.Repositories
{
    public class RiskQueryRepository : QueryRepository<RiskOwner>, IQueryRepository<RiskOwner>
    {
        public RiskQueryRepository(DbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<List<RiskOwner>> GetAll()
        {
            var item = await context.Set<RiskOwner>().Where(i => i.IsActive == true).Include(x => x.Role).ToListAsync();
            return item;
        }

        public override async Task<RiskOwner> GetById(long id)
        {
            var item =  await context.Set<RiskOwner>().Where(i => i.IsActive == true).Include(x=>x.Role).FirstOrDefaultAsync();
            return item;
        }
    }

}
