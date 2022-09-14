using Imi.Project.Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Core.Interfaces
{
{
    public interface IApiSearchService
    {
        Task<IEnumerable<JobResponseDto>> SearchJob(string query);
        Task<IEnumerable<LocationResponseDto>> SearchLocation(string continent, string country, string query);
        Task<IEnumerable<SchoolResponseDto>> SearchSchool(string query);
        Task<IEnumerable<CompanyResponseDto>> SearchCompany(string query);
    }
}
