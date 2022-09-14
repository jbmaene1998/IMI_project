using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;

namespace Imi.Project.Api.Core.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }
        public async Task<LocationResponseDto> AddAsync(LocationRequestDto requestDto)
        {
            var result = await _locationRepository.AddAsync(_mapper.DtoMapper(requestDto));
            return _mapper.DtoMapper(result);
        }
        public async Task DeleteAsync(string id)
        {
            await _locationRepository.DeleteAsync(id);
        }
        public async Task<IEnumerable<LocationResponseDto>> GetAllAsync()
        {
            var results = _locationRepository.GetAll();
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }
        public Task<LocationResponseDto> GetByIdAsync(string id)
        {
            var result = _locationRepository.GetAll()
                .SingleOrDefault(a => a.Id == id);
            return Task.FromResult(_mapper.DtoMapper(result));
        }
        public async Task<LocationResponseDto> UpdateAsync(LocationRequestDto requestDto)
        {
            var result = await _locationRepository.UpdateAsync(_mapper.DtoMapper(requestDto));
            return _mapper.DtoMapper(result);
        }

        public async Task<IEnumerable<LocationResponseDto>> GetAllCountriesByContinentAsync(string input)
        {
            var countries = _locationRepository.GetAllCountriesByContinent(input);
            return countries.Select(country => _mapper.DtoMapper(country)).ToList();
        }

        public async Task<IEnumerable<LocationResponseDto>> GetAllCitiesByCountryAsync(string continent, string country)
        {
            var cities = _locationRepository.GetAllCitiesByCountry(continent, country);
            return cities.Select(city => _mapper.DtoMapper(city)).ToList();
        }

        public async Task<IEnumerable<LocationResponseDto>> GetAllContinentsAsync()
        {
            var continents = _locationRepository.GetAllContinents();
            return continents.Select(continent => _mapper.DtoMapper(continent)).Select(dummy => (LocationResponseDto) dummy).ToList();
        }
    }
}
