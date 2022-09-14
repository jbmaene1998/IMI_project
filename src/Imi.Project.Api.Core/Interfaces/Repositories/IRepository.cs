using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Entities.BaseEntities;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(string id);
        IQueryable<T> GetAll();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(string id);
        Task<T> GetByIdAsync(string id, string[] includes);
        IQueryable<T> GetAllByIdAsync(string id, string[] includes);
    }
}
