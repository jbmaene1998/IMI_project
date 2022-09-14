using Imi.Project.Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Wpf.Core.Interfaces
{
    public interface IJobService
    {
        Task<JobResponseDto> AddJob(JobRequestDto request);
        Task DeleteJob(Guid id);
        Task<JobResponseDto> GetJob(Guid id);
        Task<IEnumerable<JobResponseDto>> GetAllJobs();

    }
}
