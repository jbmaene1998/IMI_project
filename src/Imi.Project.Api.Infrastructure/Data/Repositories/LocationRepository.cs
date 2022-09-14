using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;

namespace Imi.Project.Api.Infrastructure.Data.Repositories
{
    public class LocationRepository : EntityRepository<Location>, ILocationRepository  
    {
        public LocationRepository(ITInternshipsContextDb dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Location> GetAllCitiesByCountry(string continent, string country)
        {
            var results = GetAll().Where(l => l.Continent == continent && l.Country == country);
            return results;
        }

        public IEnumerable<dynamic> GetAllContinents()
        {
            var results = GetAll().GroupBy(l => l.Continent).Select(l => l.Key);
            return results;
        }

        public IEnumerable<string> GetAllCountriesByContinent(string continent)
        {
            var results = GetAll().Where(l => l.Continent == continent).GroupBy(l => l.Country).Select(l => l.Key);
            return results;
        }
    }
}
