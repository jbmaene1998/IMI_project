using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IVacancyService
    {
        Task<VacancyResponseDto> AddAsync(VacancyRequestDto requestDto);
        Task DeleteAsync(string id);
        Task<IEnumerable<VacancyResponseDto>> GetAllAsync();
        Task<IEnumerable<VacancyResponseDto>> GetAllByRecruiterAsync(string recruiterId);
        Task<VacancyResponseDto> GetByIdAsync(string id);
    }
}
