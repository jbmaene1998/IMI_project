using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Mobile.Core.Modals;

namespace Imi.Project.Mobile.Core.Domain.Interfaces
{
    public interface IVacancyService
    {
        Task<IQueryable<Vacancy>> GetAll();
        Task<Vacancy> GetById(string id);
        Task<Vacancy> Add(Vacancy company);
        Task<Vacancy> Update(Vacancy company);
        Task<Vacancy> Delete(string id);
        Task<List<Vacancy>> GetAllByRecruiter(Recruiter recruiter);
        bool HasRecruiterThis(Recruiter recruiter, string input);
    }
}
