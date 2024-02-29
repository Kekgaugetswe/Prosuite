using Microsoft.EntityFrameworkCore;
using Prosuite.Domain.Contracts.Interfaces.Repositories;
using Prosuite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Infrastructure.Repositories
{
    public class QueryRepository<T> : IQueryRepository<T> where T : Entity
    {
        protected DbContext context;

        public QueryRepository(DbContext context)
        {
            this.context = context;
        }

        public virtual async Task<List<T>> Filter(Expression<Func<T, bool>> predicate, int page = 1, int limit = 10)
        {
            page = page <= 0 ? 1 : page;
            var totalCount = context.Set<T>().Where(predicate).Count();
            var startRow = (page - 1) * limit;
            var items = await context.Set<T>().Where(predicate).Skip(startRow)
                       .Take(limit).ToListAsync();
            return items;
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public virtual async Task<List<T>> GetAll()
        {
            var items = await context.Set<T>().Where(i => i.IsActive == true).ToListAsync();
            return items;
        }

       

        public virtual async Task<T> GetById(long id)
        {
            var item = await context.Set<T>().Where(i => i.IsActive == true).FirstOrDefaultAsync(i => i.Id == id); 
            return item;
        }

        public async Task<T> GetByPlainId(long id)
        {
            var item = await context.Set<T>().FindAsync(id);
            return item;
        }
    }
}
