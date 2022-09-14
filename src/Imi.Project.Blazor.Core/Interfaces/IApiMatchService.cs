using Imi.Project.Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Core.Interfaces
{
    public interface IApiMatchService
    {
        Task<IEnumerable<MatchResponseDto>> GetAllByRecruiter(string id);
        Task<IEnumerable<MatchResponseDto>> GetAllByStudent(string id);
    }
}
