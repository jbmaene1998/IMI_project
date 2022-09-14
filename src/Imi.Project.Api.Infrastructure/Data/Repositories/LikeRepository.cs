using System;
using System.Collections.Generic;
using System.Linq;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Infrastructure.Data.Repositories;

namespace Imi.Project.Api.Infrastructure.Data.Repositories
{
    public class LikeRepository : EntityRepository<Like>, ILikeRepository
    {
        public LikeRepository(ITInternshipsContextDb dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Like> GetAllFromRecruiterAsync(string id)
        {
            return GetAll().Where(r => r.IsRecruiter == true && r.RecruiterId == id);
        }

        public IEnumerable<Like> GetAllFromStudentAsync(string id)
        {
            return GetAll().Where(r => r.IsRecruiter == false && r.StudentId == id);
        }
    }
}
