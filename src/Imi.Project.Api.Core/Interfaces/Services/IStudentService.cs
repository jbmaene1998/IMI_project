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
    public interface IStudentService
    {
        Task<dynamic> AddAsync(RegisterStudentRequestDto requestDto);
        Task DeleteAsync(string id);

        Task<StudentResponseDto> GetByIdAsync(string id);
        Task<IdentityResult> UpdateAsync(StudentRequestDto requestDto);
        Task<IdentityResult> UpdateAsync(Student entity);
        Task<IEnumerable<StudentResponseDto>> GetAllForRecruiterAsync(string recruiterId, string[] includes);
    }
}
