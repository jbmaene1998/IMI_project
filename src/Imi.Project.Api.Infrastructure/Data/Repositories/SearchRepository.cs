using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.BaseEntities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IJobRepository _jobRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ISchoolRepository _schoolRepository;

        public SearchRepository(ICompanyRepository companyRepository, IJobRepository jobRepository, ILocationRepository locationRepository, ISchoolRepository schoolRepository)
        {
            _companyRepository = companyRepository;
            _jobRepository = jobRepository;
            _locationRepository = locationRepository;
            _schoolRepository = schoolRepository;   
        }

        public async Task<IEnumerable<Company>> SearchCompany(string searchString)
        {
            return await _companyRepository.GetAll().Where(c => c.Name.ToLower().Contains(searchString.ToLower())).ToListAsync();
        }

        public async Task<IEnumerable<Job>> SearchJob(string searchString)
        {
            return await _jobRepository.GetAll().Where(j => j.Name.ToLower().Contains(searchString.ToLower())).ToListAsync();
        }

        public IEnumerable<Location> SearchLocation(string searchString, string continent, string country)
        {
            return _locationRepository.GetAllCitiesByCountry(continent, country).Where(j => j.City.ToLower().Contains(searchString.ToLower()));
        }

        public async Task<IEnumerable<School>> SearchSchool(string searchString)
        {
            return await _schoolRepository.GetAll().Where(s => s.Name.ToLower().Contains(searchString.ToLower())).ToListAsync();
        }
    }
}
