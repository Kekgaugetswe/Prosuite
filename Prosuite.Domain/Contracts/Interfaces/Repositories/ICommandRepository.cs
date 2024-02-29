using Prosuite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Contracts.Interfaces.Repositories
{
    public interface ICommandRepository<Ent> where Ent : Entity
    {
        Task Create(Ent ent);
        Task Update(Ent old, Ent ent);
        Task Delete(Ent id);

    }
}
