using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ILocationService
    {
        Task<LocationResponseDto> AddAsync(LocationRequestDto requestDto);
        Task DeleteAsync(string id);
        Task<IEnumerable<LocationResponseDto>> GetAllCountriesByContinentAsync(string country);
        Task<IEnumerable<LocationResponseDto>> GetAllCitiesByCountryAsync(string continent, string country);
        Task<IEnumerable<LocationResponseDto>> GetAllContinentsAsync();
        Task<LocationResponseDto> GetByIdAsync(string id);
        Task<LocationResponseDto> UpdateAsync(LocationRequestDto requestDto);
    }
}
