using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ISchoolService
    {
        Task<SchoolResponseDto> AddAsync(SchoolRequestDto requestDto);
        Task DeleteAsync(string id);
        Task<IEnumerable<SchoolResponseDto>> GetAllAsync();
        Task<SchoolResponseDto> GetByIdAsync(string id);
        Task<SchoolResponseDto> UpdateAsync(SchoolRequestDto requestDto);
    }
}
