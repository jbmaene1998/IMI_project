using CsvHelper.Configuration;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.ClassMaps
{
    public class LocationClassMap : ClassMap<Location>
    {
        public LocationClassMap()
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.City).Name("ASCIIName");
            Map(m => m.Country).Name("CountryNameEN");
            Map(m => m.Population).Name("Population");
            Map(m => m.Continent).Name("Timezone");
        }
    }
}
