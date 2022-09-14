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
    public class SearchService : ISearchService
    {
        private readonly IMapper _mapper;
        private readonly ISearchRepository _searchRepository;

        public SearchService(IMapper mapper, ISearchRepository searchRepository)
        {
            _mapper = mapper;
            _searchRepository = searchRepository;
        }

        public async Task<IEnumerable<CompanyResponseDto>> SearchCompanyAsync(string searchString)
        {
            var results =  await _searchRepository.SearchCompany(searchString);
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }

        public async Task<IEnumerable<JobResponseDto>> SearchJobAsync(string searchString)
        {
            var results =  await _searchRepository.SearchJob(searchString);
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }

        public async Task<IEnumerable<LocationResponseDto>> SearchLocationAsync(string searchString, string continent, string country)
        {
            var results =  _searchRepository.SearchLocation(searchString, continent, country);
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }

        public async Task<IEnumerable<SchoolResponseDto>> SearchSchoolAsync(string searchString)
        {
            var results = await _searchRepository.SearchSchool(searchString);
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }
    }
}
