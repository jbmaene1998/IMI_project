using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using System.Linq;
using Imi.Project.Mobile.Core.Modals;

namespace Imi.Project.Mobile.Core.Domain.Interfaces
{
    public interface IMatchService
    {
        Task<IQueryable<Match>> GetAll();
        List<Match> GetAllByRecruiter(Recruiter recruiter); 
        List<Match> GetAllByStudent(Student student);
        Task<Match> GetById(string id);
        Task<Match> Add(Match match);
        Task<Match> Update(Match match);
        Task<Match> Delete(string id);
    }
}
