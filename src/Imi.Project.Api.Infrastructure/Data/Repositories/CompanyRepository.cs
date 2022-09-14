using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;

namespace Imi.Project.Api.Infrastructure.Data.Repositories
{
    public class CompanyRepository : EntityRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ITInternshipsContextDb dbContext) : base(dbContext)
        {

        }
    }
}
