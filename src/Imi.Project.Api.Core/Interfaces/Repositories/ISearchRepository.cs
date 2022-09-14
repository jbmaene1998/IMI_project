using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface ISearchRepository
    {
        Task<IEnumerable<Company>> SearchCompany(string searchString);
        Task<IEnumerable<Job>> SearchJob(string searchString);
        IEnumerable<Location> SearchLocation(string searchString, string continent, string country);
        Task<IEnumerable<School>> SearchSchool(string searchString);
    }
}
