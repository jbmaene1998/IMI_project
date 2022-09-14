using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Domain.Services.Mocking
{
    public class MockCompanyService : ICompanyService
    {
        private static List<Company> companies = new List<Company>
        {
            new Company
            {
                Id = "00000000-0000-0000-0000-000000000100",
                Name = "IT Recruitment",
                Street = "Rijselstraat 2",
                PostCode = 6969,
                WebsiteUrl = "www.itcompany.io"
            },
            new Company
            {
                Id = "00000000-0000-0000-0000-000000000200",
                Name = "IT World",
                Street = "Noorstraat 2",
                PostCode = 4000,
                WebsiteUrl = "www.itworld.io"
            },
            new Company
            {
                Id = "00000000-0000-0000-0000-000000000300",
                Name = "IT Solutions",
                Street = "Nieuwstraat 2",
                PostCode = 6969,
                WebsiteUrl = "www.itsolutions.io"
            },
        };
        public async Task<Company> Add(Company company)
        {
            companies.Add(company);
            return await Task.FromResult(company);
        }

        public async Task<Company> Delete(string id)
        {
            var companyToDelete = companies.FirstOrDefault(e => e.Id == id);
            companies.Remove(companyToDelete);
            return await Task.FromResult(companyToDelete);
        }

        public async Task<IQueryable<Company>> GetAll()
        {
            var companiesList = companies.AsQueryable();
            return await Task.FromResult(companiesList);
        }

        public async Task<Company> GetById(string id)
        {
            var job = companies.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(job);
        }

        public async Task<Company> Update(Company company)
        {
            var companyToUpdate = companies.FirstOrDefault(e => e.Id == company.Id);
            companies.Remove(companyToUpdate);
            companies.Add(company);
            return await Task.FromResult(company);
        }
    }
}
