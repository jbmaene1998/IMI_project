using System;
using System.Collections.Generic;
using System.Text;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface ILocationRepository : IEntityRepository<Location>
    {
        IEnumerable<string> GetAllCountriesByContinent(string country);
        IEnumerable<Location> GetAllCitiesByCountry(string continent, string country);
        IEnumerable<dynamic> GetAllContinents();
    }
}
