using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;

namespace Imi.Project.Api.Infrastructure.Data.Repositories
{
    public class SchoolRepository : EntityRepository<School>, ISchoolRepository
    {
        public SchoolRepository(ITInternshipsContextDb dbContext) : base(dbContext)
        {

        }
    }
}
