using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;

namespace Imi.Project.Api.Infrastructure.Data.Repositories
{
    public class JobRepository : EntityRepository<Job>, IJobRepository
    {
        public JobRepository(ITInternshipsContextDb dbContext) : base(dbContext)
        {

        }
    }
}
