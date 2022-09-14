using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<CompanyResponseDto>> SearchCompanyAsync(string searchString);
        Task<IEnumerable<JobResponseDto>> SearchJobAsync(string searchString);
        Task<IEnumerable<SchoolResponseDto>> SearchSchoolAsync(string searchString);
        Task<IEnumerable<LocationResponseDto>> SearchLocationAsync(string searchString, string continent, string country);
    }
}
