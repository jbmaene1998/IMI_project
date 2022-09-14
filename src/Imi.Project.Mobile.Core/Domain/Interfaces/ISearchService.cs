using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Domain.Interfaces
{
    public interface ISearchService
    {
        Task<List<Company>> SearchCompany(string searchString);
        Task<List<Job>> SearchJob(string searchString);
        Task<List<School>> SearchSchool(string searchString);
        Task<List<Company>> SearchLocation(string searchString);
    }
}
