using CsvHelper.Configuration;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.ClassMaps
{
    public class StudentClassMap : ClassMap<Student>
    {
        public StudentClassMap()
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.FirstName).Name("FirstName");
            Map(m => m.LastName).Name("LastName");
            Map(m => m.DateOfBirth).Name("DateOfBirth");
            Map(m => m.Email).Name("Email");
            Map(m => m.PhoneNumber).Name("Phone");
        }
    }
}
