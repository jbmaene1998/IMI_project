using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Data
{
    public interface ICsvService
    {
        List<Location> ReadLocations();
        List<School> ReadSchools();
        List<Company> ReadCompanies();
        List<Student> ReadStudents();
        List<Recruiter> ReadRecruiters();
    }
}
