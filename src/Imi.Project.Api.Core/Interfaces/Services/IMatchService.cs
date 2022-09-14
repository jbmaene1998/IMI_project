using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IMatchService
    {
        Task<MatchResponseDto> AddAsync(MatchRequestDto requestDto);
        Task<IEnumerable<MatchResponseDto>> GetAllAsync();
        Task<MatchResponseDto> GetByIdAsync(string id);
        Task DeleteAsync(string id);
        Task<IEnumerable<MatchResponseDto>> GetMatchesByStudentAsync(string id);
        Task<IEnumerable<MatchResponseDto>> GetMatchesByRecruiterAsync(string id);
    }
}
