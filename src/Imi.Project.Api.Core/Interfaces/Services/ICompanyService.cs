using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<CompanyResponseDto> AddAsync(CompanyRequestDto requestDto);
        Task DeleteAsync(string id);
        Task<IEnumerable<CompanyResponseDto>> GetAllAsync();
        Task<CompanyResponseDto> GetByIdAsync(string id);
        Task<CompanyResponseDto> UpdateAsync(CompanyRequestDto requestDto);
    }
}
