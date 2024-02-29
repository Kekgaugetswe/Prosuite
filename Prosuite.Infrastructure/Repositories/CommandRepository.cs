using Microsoft.AspNetCore.Http;
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
    public class CommandRepository<T> : ICommandRepository<T> where T : Entity
    {
        DbContext context;
        public CommandRepository(DbContext context)
        {
            this.context = context;
        }

        public async Task Create(T item)
        {
            item.CreatedAt = DateTime.Now;
            item.IsActive = true;
            item.CreatedBy = "kekgaugetswe";
            item.UpdatedBy = "notyet";
            context.Set<T>().Add(item);
            await context.SaveChangesAsync();
        }

        public async Task Delete(T itemToDelete)
        {
            _ = new Entity();
            Entity deletedItem = itemToDelete;
            deletedItem.IsActive = false;
            deletedItem.UpdatedAt = DateTime.Now;
            context.Entry(itemToDelete).CurrentValues.SetValues(deletedItem);
            await context.SaveChangesAsync();
        }

        public async Task Update(T old, T newItem)
        {
            newItem.UpdatedAt = DateTime.Now;

            context.Entry(old).CurrentValues.SetValues(newItem);

            await context.SaveChangesAsync();
        }


    }
}
