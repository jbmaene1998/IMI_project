using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IRecruiterService
    {
        Task<dynamic> AddAsync(RegisterRecruiterRequestDto requestDto);
        Task DeleteAsync(string id);
        Task<RecruiterResponseDto> GetByIdAsync(string id);
        Task<IdentityResult> UpdateAsync(RecruiterRequestDto requestDto);
        Task<IdentityResult> UpdateAsync(Recruiter entity);
        Task<IEnumerable<RecruiterResponseDto>> GetAllForStudentAsync(string studentId, string[] includes);
    }
}
