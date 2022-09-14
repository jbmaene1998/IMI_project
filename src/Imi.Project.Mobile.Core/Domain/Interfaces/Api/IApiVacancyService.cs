using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Core.Interfaces
{
{
    public interface IApiVacancyService
    {
        Task<IEnumerable<VacancyResponseDto>> GetAllVacancies(string id);
        Task<bool> HasRecruiterThis(string input);
        Task<VacancyResponseDto> Add(VacancyRequestDto request);
        Task Delete(string id);
        Task<VacancyResponseDto> Get(string id);
    }
}
