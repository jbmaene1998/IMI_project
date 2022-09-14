using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;

namespace Imi.Project.Api.Infrastructure.Data.Repositories
{
    public class VacancyRepository : EntityRepository<Vacancy>, IVacancyRepository
    {
        public VacancyRepository(ITInternshipsContextDb dbContext) : base(dbContext)
        {

        }
    }
}