using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IJobService
    {
        Task<JobResponseDto> AddAsync(JobRequestDto requestDto);
        Task DeleteAsync(string id);
        IEnumerable<JobResponseDto> GetAll();
        Task<JobResponseDto> GetByIdAsync(string id);
        Task<JobResponseDto> UpdateAsync(JobRequestDto requestDto);
    }
}
