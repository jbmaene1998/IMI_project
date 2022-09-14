using Imi.Project.Api.Core.Dtos;
using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Domain.Interfaces.Api
{
    public interface IApiLikeService
    {
        Task<IEnumerable<LikeResponseDto>> GetAllFromRecruiter(string recruiterId);
        Task<IEnumerable<LikeResponseDto>> GetAllFromStudent(string studentId);
        Task<LikeResponseDto> Add(LikeRequestDto requestDto);
    }
}
