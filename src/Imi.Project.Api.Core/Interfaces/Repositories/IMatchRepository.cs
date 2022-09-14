using System;
using System.Collections.Generic;
using System.Text;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IMatchRepository : IEntityRepository<Match>
    {
        IEnumerable<Match> GetMatchesByStudent(string id);
        IEnumerable<Match> GetMatchesByRecruiter(string id);
    }
}
