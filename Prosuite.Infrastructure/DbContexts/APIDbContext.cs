using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Prosuite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Infrastructure.DbContexts
{
    public class APIDbContext :DbContext
    {
        private IConfiguration configuration;
        public APIDbContext(DbContextOptions<APIDbContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<RiskOwner> RiskOwner { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
