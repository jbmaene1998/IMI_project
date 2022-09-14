using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Domain.Interfaces
{
    public interface ICompanyService
    {
        Task<IQueryable<Company>> GetAll();
        Task<Company> GetById(string id);
        Task<Company> Add(Company company);
        Task<Company> Update(Company company);
        Task<Company> Delete(string id);
    }
}
