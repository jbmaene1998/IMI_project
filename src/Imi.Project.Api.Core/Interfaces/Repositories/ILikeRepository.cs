using System;
using System.Collections.Generic;
using System.Text;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface ILikeRepository : IEntityRepository<Like>
    {
        IEnumerable<Like> GetAllFromRecruiterAsync(string id);
        IEnumerable<Like> GetAllFromStudentAsync(string id);
    }
}
