using Prosuite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Domain.Contracts.Interfaces.Repositories
{
    public interface IQueryRepository<Ent> where Ent : Entity
    {
        Task<List<Ent>> Filter(Expression<Func<Ent, bool>> predicate, int pageNumber = 1, int pageSize = 10);
        IQueryable<Ent> Filter(Expression<Func<Ent, bool>> predicate);
        Task<Ent> GetById(long id);
        Task<Ent> GetByPlainId(long id);
        Task<List<Ent>> GetAll();
    }
}
