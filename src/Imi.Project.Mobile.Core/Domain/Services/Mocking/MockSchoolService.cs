using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Domain.Services.Mocking
{
    public class MockSchoolService : ISchoolService
    {
        private static List<School> schools = new List<School>
        {
            new School
            {
                Id = "00000000-0000-0000-0000-000000000001",
                Name = "Howest",
                Street = "Bruggestraat 4",
                PostCode = 8400,
                WebsiteUrl = "www.howest.io",
            },
            new School
            {
                Id = "00000000-0000-0000-0000-000000000002",
                Name = "Vives",
                Street = "Oostendestraat 4",
                PostCode = 8400,
                WebsiteUrl = "www.vives.io"
            },
            new School
            {
                Id = "00000000-0000-0000-0000-000000000003",
                Name = "Dae",
                Street = "Kortrijkstraat 4",
                PostCode = 8500,
                WebsiteUrl = "www.dae.io"
            },
        };
        public async Task<School> Add(School school)
        {
            schools.Add(school);
            return await Task.FromResult(school);
        }

        public async Task<School> Delete(string id)
        {
            var schoolToDelete = schools.FirstOrDefault(e => e.Id == id);
            schools.Remove(schoolToDelete);
            return await Task.FromResult(schoolToDelete);
        }

        public async Task<IQueryable<School>> GetAll()
        {
            var schoolList = schools.AsQueryable();
            return await Task.FromResult(schoolList);
        }

        public async Task<School> GetById(string id)
        {
            var job = schools.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(job);
        }

        public async Task<School> Update(School school)
        {
            var schoolToUpdate = schools.FirstOrDefault(e => e.Id == school.Id);
            schools.Remove(schoolToUpdate);
            schools.Add(school);
            return await Task.FromResult(school);
        }
    }
}
