using Imi.Project.Api.Core.Dtos;
using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Core.Interfaces
{
    public interface IApiRecruiterService
    {
        Task<RecruiterResponseDto> GetById(string id);
        Task<RecruiterResponseDto> Add(RegisterRecruiterRequestDto recruiter);
        Task<RecruiterResponseDto> Update(RecruiterRequestDto dto);
        Task<IEnumerable<RecruiterResponseDto>> GetPotentialRecruiters(string recruiterId);
    }
}
