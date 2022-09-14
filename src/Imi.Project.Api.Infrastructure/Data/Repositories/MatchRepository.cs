using System;
using System.Collections.Generic;
using System.Linq;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Imi.Project.Api.Infrastructure.Data.Repositories
{
    public class MatchRepository : EntityRepository<Match>, IMatchRepository
    {
        public MatchRepository(ITInternshipsContextDb dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Match> GetMatchesByRecruiter(string id)
        {
            var matches = GetAll()
                .Include(m => m.Student)
                .Include(m => m.Recruiter)
                .Where(m => m.RecruiterId == id)
                .ToList();
            return matches;
        }

        public IEnumerable<Match> GetMatchesByStudent(string id)
        {
            var matches = GetAll()
                .Include(m => m.Student)
                .Include(m => m.Recruiter)
                .Where(m => m.StudentId == id)
                .ToList();
            return matches;
        }
    }
}
