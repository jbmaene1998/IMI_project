using CsvHelper.Configuration;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.ClassMaps
{
    public class RecruiterClassMap : ClassMap<Recruiter>
    {
        public RecruiterClassMap()
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.FirstName).Name("FirstName");
            Map(m => m.LastName).Name("LastName");
            Map(m => m.PhoneNumber).Name("Phone");
            Map(m => m.Email).Name("Email");
            Map(m => m.DateOfBirth).Name("DateOfBirth");
        }
    }
}
