using Imi.Project.Api.Core.Entities.BaseEntities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Imi.Project.Api.Infrastructure.Data.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : BaseEntity
    {
        protected readonly ITInternshipsContextDb DbContext;

        public EntityRepository(ITInternshipsContextDb dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>().AsNoTracking();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdAsync(string id, string[] includes)
        {
            var query = DbContext.Set<T>().AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.SingleOrDefaultAsync(t => t.Id.Equals(id));
        }

        public IQueryable<T> GetAllByIdAsync(string id, string[] includes)
        {
            var query = DbContext.Set<T>().AsQueryable();
            return includes.Aggregate(query, (current, include) => current.Include(include));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Detached;
            await DbContext.SaveChangesAsync();
            return entity;
        }
    }
}
