using CsvHelper.Configuration;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.ClassMaps
{
    public class CompanyClassMap : ClassMap<Company>
    {
        public CompanyClassMap()
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.Name).Name("Name");
            Map(m => m.Street).Name("Street");
            Map(m => m.PostCode).Name("PostCode");
            Map(m => m.WebsiteUrl).Name("WebsiteUrl");
        }
    }
}
