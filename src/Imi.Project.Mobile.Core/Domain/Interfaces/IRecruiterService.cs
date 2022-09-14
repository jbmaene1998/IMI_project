using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Imi.Project.Mobile.Core.Modals;

namespace Imi.Project.Mobile.Core.Domain.Interfaces
{
    public interface IRecruiterService
    {
        Task<IQueryable<Recruiter>> GetAll();
        Task<Recruiter> GetById(string id);
        Task<Recruiter> Add(Recruiter recruiter);
        Task<Recruiter> Update(Recruiter recruiter);
        Task<Recruiter> Delete(string id);
    }
}
