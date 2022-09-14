using Imi.Project.Mobile.Core.Domain.Interfaces;

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Mobile.Core.Modals;

namespace Imi.Project.Mobile.Core.Domain.Services.Mocking
{
    public class MockRecruiterService : IRecruiterService
    {
        private static List<Recruiter> recruiters = new List<Recruiter>
        {
            new Recruiter
            {
                Id = "00000000-0000-0000-0000-000000000010",
                FirstName = "Laure",
                LastName = "NiDalé",
                DateOfBirth = DateTime.Parse("12/12/1999"),
                Email = "Laure@recruiter.be",
                Phone = "0496208756",
                ImageUrl = "https://thispersondoesnotexist.com/image",
                Password = "pasword",
                CompanyId = "00000000-0000-0000-0000-000000000100"
            },
            new Recruiter
            {
                Id = "00000000-0000-0000-0000-000000000020",
                FirstName = "Julie",
                LastName = "NiDalé",
                DateOfBirth = DateTime.Parse("12/12/1999"),
                Email = "Julie@recruiter.be",
                Phone = "0496208756",
                ImageUrl = "https://thispersondoesnotexist.com/image",
                Password = "pasword",
                CompanyId = "00000000-0000-0000-0000-000000000200"
            },
            new Recruiter
            {
                Id = "00000000-0000-0000-0000-000000000030",
                FirstName = "Jens",
                LastName = "NiDalé",
                DateOfBirth = DateTime.Parse("12/12/1999"),
                Email = "jens@recruiter.be",
                Phone = "0496208756",
                ImageUrl = "https://thispersondoesnotexist.com/image",
                Password = "pasword",
                CompanyId = "00000000-0000-0000-0000-000000000300"
            }
        };
        public async Task<Recruiter> Add(Recruiter recruiter)
        {
            recruiters.Add(recruiter);
            return await Task.FromResult(recruiter);
        }

        public async Task<Recruiter> Delete(string id)
        {
            var recruiterToDelete = recruiters.FirstOrDefault(e => e.Id == id);
            recruiters.Remove(recruiterToDelete);
            return await Task.FromResult(recruiterToDelete);
        }

        public async Task<IQueryable<Recruiter>> GetAll()
        {
            var recruiterList = recruiters.AsQueryable();
            return await Task.FromResult(recruiterList);
        }

        public async Task<Recruiter> GetById(string id)
        {
            var recruiter = recruiters.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(recruiter);
        }

        public async Task<Recruiter> Update(Recruiter recruiter)
        {
            var recruiterToUpdate = recruiters.FirstOrDefault(e => e.Id == recruiter.Id);
            recruiters.Remove(recruiterToUpdate);
            recruiters.Add(recruiter);
            return await Task.FromResult(recruiter);
        }
    }
}
