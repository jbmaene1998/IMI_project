using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Domain.Services.Mocking
{
    public class MockSearchService : ISearchService
    {
        private readonly ICompanyService _companyService;
        private readonly IJobService _jobService;
        private readonly ISchoolService _schoolService;
        public MockSearchService()
        {
            _companyService = new MockCompanyService();
            _jobService = new MockJobService();
            _schoolService = new MockSchoolService();
        }
        public async Task<List<Company>> SearchCompany(string searchString)
        {
            var companies = await _companyService.GetAll();
            var companiesFound = companies.Where(s => s.Name.ToLower().Contains(searchString.ToLower())).ToList();
            return companiesFound;
        }

        public async Task<List<Company>> SearchLocation(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Job>> SearchJob(string searchString)
        {
            throw new NotImplementedException();
        }

        public async Task<List<School>> SearchSchool(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
