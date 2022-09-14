using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IMessageService
    {
        Task<MessageResponseDto> AddAsync(MessageRequestDto requestDto);
        Task<IEnumerable<MessageResponseDto>> GetAllAsync();
        Task<IEnumerable<MessageResponseDto>> GetAllFromStudentAsync(string studentId, string recruiterId);
        Task<IEnumerable<MessageResponseDto>> GetAllFromRecruiterAsync(string recruiterId, string studentId);
    }
}
