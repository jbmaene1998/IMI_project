using Imi.Project.Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Core.Interfaces
{
    public interface IApiStudentService
    {
        Task<StudentResponseDto> GetById(string id);
        Task<StudentResponseDto> Add(RegisterStudentRequestDto dto);
        Task<StudentResponseDto> Update(StudentRequestDto dto);
        Task<IEnumerable<StudentResponseDto>> GetPotentialStudents(string recruiterId);
    }
}
