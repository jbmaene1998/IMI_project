using Imi.Project.Mobile.Core.Domain.Interfaces;

using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Imi.Project.Mobile.Core.Domain.Services.Mocking
{
    public class MockMatchService : IMatchService
    {
        private static List<Match> matches = new List<Match>
        {
            //1
            new Match
            {
                Id = "00000000-0000-0000-0000-000000000111",
                CreateDate = DateTime.Parse("1/12/2020"),
                RecruiterId = "00000000-0000-0000-0000-000000000010",
                StudentId = "00000000-0000-0000-0000-000000001000"
            },
            new Match
            {
                Id = "00000000-0000-0000-0000-000000000222",
                CreateDate = DateTime.Parse("1/10/2020"),
                RecruiterId = "00000000-0000-0000-0000-000000000010",
                StudentId = "00000000-0000-0000-0000-000000002000"
            },
            new Match
            {
                Id = "00000000-0000-0000-0000-000000000333",
                CreateDate = DateTime.Parse("1/9/2020"),
                RecruiterId = "00000000-0000-0000-0000-000000000010",
                StudentId = "00000000-0000-0000-0000-000000003000"
            },
            //2
            new Match
            {
                Id = "00000000-0000-0000-0000-000000000444",
                CreateDate = DateTime.Parse("1/2/2020"),
                RecruiterId = "00000000-0000-0000-0000-000000000020",
                StudentId = "00000000-0000-0000-0000-000000003000"
            },
            new Match
            {
                Id = "00000000-0000-0000-0000-000000000555",
                CreateDate = DateTime.Parse("1/5/2020"),
                RecruiterId = "00000000-0000-0000-0000-000000000020",
                StudentId = "00000000-0000-0000-0000-000000001000"
            },
            new Match
            {
                Id = "00000000-0000-0000-0000-000000000666",
                CreateDate = DateTime.Parse("1/4/2020"),
                RecruiterId = "00000000-0000-0000-0000-000000000020",
                StudentId = "00000000-0000-0000-0000-000000002000"
            },
            //3
            new Match
            {
                Id = "00000000-0000-0000-0000-000000000777",
                CreateDate = DateTime.Parse("1/3/2020"),
                RecruiterId = "00000000-0000-0000-0000-000000000030",
                StudentId = "00000000-0000-0000-0000-000000003000"
            },
            new Match
            {
                Id = "00000000-0000-0000-0000-000000000888",
                CreateDate = DateTime.Parse("1/3/2020"),
                RecruiterId = "00000000-0000-0000-0000-000000000030",
                StudentId = "00000000-0000-0000-0000-000000004000"
            },
            new Match
            {
                Id = "00000000-0000-0000-0000-000000000999",
                CreateDate = DateTime.Parse("1/3/2020"),
                RecruiterId = "00000000-0000-0000-0000-000000000030",
                StudentId = "00000000-0000-0000-0000-000000001000"
            },
            //4
            new Match
            {
                Id = "00000000-0000-0000-0000-000000001111",
                CreateDate = DateTime.Parse("1/3/2020"),
                RecruiterId = "00000000-0000-0000-0000-000000000040",
                StudentId = "00000000-0000-0000-0000-000000002000"
            },
            new Match
            {
                Id = "00000000-0000-0000-0000-000000002222",
                CreateDate = DateTime.Parse("1/3/2020"),
                RecruiterId = "00000000-0000-0000-0000-000000000040",
                StudentId = "00000000-0000-0000-0000-000000004000"
            },
            new Match
            {
                Id = "00000000-0000-0000-0000-000000003333",
                CreateDate = DateTime.Parse("1/3/2020"),
                RecruiterId = "00000000-0000-0000-0000-000000000040",
                StudentId = "00000000-0000-0000-0000-000000003000"
            },


        };
        public async Task<Match> Add(Match match)
        {
            matches.Add(match);
            return await Task.FromResult(match);
        }

        public async Task<Match> Delete(string id)
        {
            var matchToDelete = matches.FirstOrDefault(e => e.Id == id);
            matches.Remove(matchToDelete);
            return await Task.FromResult(matchToDelete);
        }

        public async Task<IQueryable<Match>> GetAll()
        {
            var matchList = matches.AsQueryable();
            return await Task.FromResult(matchList);
        }

        public List<Match> GetAllByRecruiter(Recruiter recruiter)
        {
            var matchesByRecruiter = matches.Where(m => m.RecruiterId == recruiter.Id).ToList();
            return matchesByRecruiter;
        }

        public List<Match> GetAllByStudent(Student student)
        {
            var matchesByStudent = matches.Where(m => m.StudentId == student.Id).ToList();
            return matchesByStudent;
        }

        public async Task<Match> GetById(string id)
        {
            var match = matches.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(match);
        }

        public async Task<Match> Update(Match match)
        {
            var matchToUpdate = matches.FirstOrDefault(e => e.Id == match.Id);
            matches.Remove(matchToUpdate);
            matches.Add(match);
            return await Task.FromResult(match);
        }
    }
}
