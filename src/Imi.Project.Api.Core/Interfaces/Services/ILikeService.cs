using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ILikeService
    {
        Task<LikeResponseDto> AddAsync(LikeRequestDto requestDto);
        Task<IEnumerable<LikeResponseDto>> GetAllAsync();
        Task<IEnumerable<LikeResponseDto>> GetAllFromStudentAsync(string id);
        Task<IEnumerable<LikeResponseDto>> GetAllFromRecruiterAsync(string id);
    }
}
