using Imi.Project.Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Core.Interfaces
{
    public interface IApiJobService
    {
        Task<JobResponseDto> Add(JobRequestDto request);
        Task Delete(string id);
        Task<JobResponseDto> Get(string id);
    }
}
