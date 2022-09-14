using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Imi.Project.Mobile.Core.Modals;

namespace Imi.Project.Mobile.Core.Domain.Interfaces
{
    public interface ISchoolService
    {
        Task<IQueryable<School>> GetAll();
        Task<School> GetById(string id);
        Task<School> Add(School school);
        Task<School> Update(School school);
        Task<School> Delete(string id);
    }
}
