using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Domain.Services.Mocking
{
    public class MockVacancyService : IVacancyService
    {
        private static List<Vacancy> vacancies = new List<Vacancy>
        {
            new Vacancy
            {
                Id = "00000000-0000-0000-0000-000000000011",
                Name = ".Net Engineer",
                RecruiterId = "00000000-0000-0000-0000-000000000010"
            },
            new Vacancy
            {
                Id = "00000000-0000-0000-0000-000000000022",
                Name = "Java Engineer",
                RecruiterId = "00000000-0000-0000-0000-000000000010"
            },
            new Vacancy
            {
                Id = "00000000-0000-0000-0000-000000000033",
                Name = "Python Engineer",
                RecruiterId = "00000000-0000-0000-0000-000000000010"
            },
            new Vacancy
            {
                Id = "00000000-0000-0000-0000-000000000044",
                Name = ".Net Engineer",
                RecruiterId = "00000000-0000-0000-0000-000000000020"
            },
            new Vacancy
            {
                Id = "00000000-0000-0000-0000-000000000055",
                Name = "Java Engineer",
                RecruiterId = "00000000-0000-0000-0000-000000000020"
            },
            new Vacancy
            {
                Id = "00000000-0000-0000-0000-000000000066",
                Name = "Python Engineer",
                RecruiterId = "00000000-0000-0000-0000-000000000020"
            },
            new Vacancy
            {
                Id = "00000000-0000-0000-0000-000000000077",
                Name = ".Net Engineer",
                RecruiterId = "00000000-0000-0000-0000-000000000030"
            },
            new Vacancy
            {
                Id = "00000000-0000-0000-0000-000000000088",
                Name = "Java Engineer",
                RecruiterId = "00000000-0000-0000-0000-000000000030"
            },
            new Vacancy
            {
                Id = "00000000-0000-0000-0000-000000000099",
                Name = "Python Engineer",
                RecruiterId = "00000000-0000-0000-0000-000000000030"
            },

        };
        public async Task<Vacancy> Add(Vacancy vacancie)
        {
            vacancies.Add(vacancie);
            return await Task.FromResult(vacancie);
        }

        public async Task<Vacancy> Delete(string id)
        {
            var vacancieToDelete = vacancies.FirstOrDefault(e => e.Id == id);
            vacancies.Remove(vacancieToDelete);
            return await Task.FromResult(vacancieToDelete);
        }

        public async Task<IQueryable<Vacancy>> GetAll()
        {
            var vacancyList = vacancies.AsQueryable();
            return await Task.FromResult(vacancyList);
        }

        public async Task<List<Vacancy>> GetAllByRecruiter(Recruiter recruiter)
        {
            var vacanciesByRecruiter = vacancies.Where(v => v.RecruiterId == recruiter.Id).ToList();
            return await Task.FromResult(vacanciesByRecruiter);
        }

        public async Task<Vacancy> GetById(string id)
        {
            var vacancie = vacancies.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(vacancie);
        }

        public bool HasRecruiterThis(Recruiter recruiter, string input)
        {
            var results = vacancies.Where(v => v.RecruiterId == recruiter.Id && v.Name == input);
            if (results.Count() == 0)
            {
                return  true;
            }
            return false;
        }

        public async Task<Vacancy> Update(Vacancy vacancie)
        {
            var vacancieToUpdate = vacancies.FirstOrDefault(e => e.Id == vacancie.Id);
            vacancies.Remove(vacancieToUpdate);
            vacancies.Add(vacancie);
            return await Task.FromResult(vacancie);
        }
    }
}
