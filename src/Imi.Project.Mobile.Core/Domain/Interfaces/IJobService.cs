using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Imi.Project.Mobile.Core.Modals;

namespace Imi.Project.Mobile.Core.Domain.Interfaces
{
    public interface IJobService
    {
        Task<IQueryable<Job>> GetAll();
        Task<Job> GetById(string id);
        Task<Job> Add(Job job);
        Task<Job> Update(Job job);
        Task<Job> Delete(string id);
    }
}
