using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Interfaces.Data
{
    public interface IDataSeederService : ICsvService
    {
        List<Like> CreateLikes();
        List<School> CreateSchools();
        List<Company> CreateCompanies();
        List<Job> CreateJobs();
        List<Student> CreateStudents();
        List<Recruiter> CreateRecruiters();
        List<Vacancy> CreateVacancies();
        List<Match> CreateMatches();
        List<Location> CreateLocations();
        List<IdentityRole> CreateRoles();
        List<IdentityUserRole<string>> CreateIdentityUserRole();
        DateTime RandomDay();
    }
}
