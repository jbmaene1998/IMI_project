using Imi.Project.Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Core.Interfaces
{
    public interface IApiLocationService
    {
        Task<LocationResponseDto> GetLocationById(string locationId);
        Task<IEnumerable<LocationResponseDto>> GetCountriesByContinent(string query);
        Task<IEnumerable<LocationResponseDto>> GetContinents();
    }
}
