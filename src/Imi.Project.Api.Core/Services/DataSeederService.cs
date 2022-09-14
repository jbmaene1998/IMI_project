 using CsvHelper;
using Imi.Project.Api.Core.ClassMaps;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Imi.Project.Api.Core.Interfaces.Data;
using Microsoft.AspNetCore.Identity;
using Imi.Project.Api.Core.Interfaces.Services;

namespace Imi.Project.Api.Core.Services
{
    public class DataSeederService : IDataSeederService
    {
        private List<Like> likes;
        private List<Company> companies;
        private List<School> schools;
        private static List<Recruiter> recruiters;
        private List<Job> jobs;
        private static List<Student> students;
        private List<Match> matches;
        private static List<Admin> admins;
        private List<Vacancy> vacancies;
        private List<Location> locations;
        private List<IdentityRole> roles;
        private List<IdentityUserRole<string>> userRoles;
        private List<IdentityUserClaim<string>> userClaims;

        public List<IdentityRole> CreateRoles()
        {
            roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "FFF3C1DF-94F5-4BA3-BEC0-5EDFDA7B7811",
                    Name = "Student",
                    NormalizedName = "STUDENT"
                },
                new IdentityRole
                {
                    Id = "65599E99-9CE5-44D1-AB4C-362F5B0EDF0E",
                    Name = "Recruiter",
                    NormalizedName = "RECRUITER"
                },
                new IdentityRole
                {
                    Id = "5840F6C7-F9D3-4BDA-B820-D183B35CF26A",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
            };
            return roles;
        }

        public List<IdentityUserRole<string>> CreateIdentityUserRole()
        {
            userRoles = new List<IdentityUserRole<string>>();

            foreach (var recruiter in ReadRecruiters())
            {
               userRoles.Add(new IdentityUserRole<string> { RoleId = "65599E99-9CE5-44D1-AB4C-362F5B0EDF0E", UserId = recruiter.Id });
            }
            foreach (var student in ReadStudents())
            {
                userRoles.Add(new IdentityUserRole<string> { RoleId = "FFF3C1DF-94F5-4BA3-BEC0-5EDFDA7B7811", UserId = student.Id });
            }

            userRoles.Add(new IdentityUserRole<string> { RoleId = "5840F6C7-F9D3-4BDA-B820-D183B35CF26A", UserId = "85F75C02-87D8-4865-B6C3-D0413C710BED"});
            return userRoles;
        }

        public List<Admin> CreateAdmins()
        {
            IPasswordHasher<Admin> hasher = new PasswordHasher<Admin>();
            admins = new List<Admin>();
            var admin = new Admin
            {
                Id = "85F75C02-87D8-4865-B6C3-D0413C710BED",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "it.internships@admin.ru",
                NormalizedEmail = ("it.internships@admin.ru").ToUpper(),
                PhoneNumber = "04846956956",
                DateOfBirth = DateTime.Now,
                LocationId = "f924102e-3dd4-4837-b2f2-ef6cfdcc8bd1",
                FirstName = "Johhny",
                LastName = "Sins",
                ImageUrl = "https://thispersondoesnotexist.com/image",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                IsRecruiter = false,
                IsAdmin = true,
                HasApprovedTermsAndConditions = true,
            };
            admin.PasswordHash = hasher.HashPassword(admin, "Test123?");
            admins.Add(admin);


            return admins;
        }

        public List<IdentityUserClaim<string>> CreateIdentityUserClaims()
        {
            userClaims = new List<IdentityUserClaim<string>>();

            for (int i = 1; i < ReadRecruiters().Count; i++)
            {
                Student student = students[i];
                userClaims.Add(new IdentityUserClaim<string> { Id = i, UserId = student.Id, ClaimType = "acceptedtermsandconditions", ClaimValue = student.HasApprovedTermsAndConditions.ToString() });
           }
            for (int i = 1; i < ReadRecruiters().Count; i++)
            {

                Recruiter recruiter = recruiters[i];
                userClaims.Add(new IdentityUserClaim<string> { Id = ReadStudents().Count + i + 1, UserId = recruiter.Id, ClaimType = "acceptedtermsandconditions", ClaimValue = recruiter.HasApprovedTermsAndConditions.ToString() });
                userClaims.Add(new IdentityUserClaim<string> { Id = ReadStudents().Count + i + 1000, UserId = recruiter.Id, ClaimType = "id", ClaimValue = recruiter.Id.ToString() });
                userClaims.Add(new IdentityUserClaim<string> { Id = ReadStudents().Count + i + 2000, UserId = recruiter.Id, ClaimType = "username", ClaimValue = recruiter.UserName.ToString() });
                userClaims.Add(new IdentityUserClaim<string> { Id = ReadStudents().Count + i + 3000, UserId = recruiter.Id, ClaimType = "email", ClaimValue = recruiter.Email.ToString() });
            }


            userClaims.Add(new IdentityUserClaim<string> { Id = 111111111, UserId = "85F75C02-87D8-4865-B6C3-D0413C710BED", ClaimType = "acceptedtermsandconditions", ClaimValue = "True" });
            userClaims.Add(new IdentityUserClaim<string> { Id = 222222222, UserId = "85F75C02-87D8-4865-B6C3-D0413C710BED", ClaimType = "id", ClaimValue = "85F75C02-87D8-4865-B6C3-D0413C710BED" });
            userClaims.Add(new IdentityUserClaim<string> { Id = 333333333, UserId = "85F75C02-87D8-4865-B6C3-D0413C710BED", ClaimType = "username", ClaimValue = "PriAdmin" });
            userClaims.Add(new IdentityUserClaim<string> { Id = 444444444, UserId = "85F75C02-87D8-4865-B6C3-D0413C710BED", ClaimType = "email", ClaimValue = "it.internships@admin.ru" });

            return userClaims;
        }

        public List<Company> CreateCompanies()
        {
            companies = new List<Company>();
            var records = ReadCompanies();
            var locations = ReadLocations();
            for (var i = 0; i < records.Count; i++)
            {
                var _rnd = new Random();
                var company = new Company
                {
                    Id = records[i].Id,
                    Name = records[i].Name,
                    PostCode = records[i].PostCode,
                    Street = records[i].Street,
                    WebsiteUrl = records[i].WebsiteUrl,
                    LocationId = locations[Convert.ToInt32(_rnd.Next(1, locations.Count))].Id
                };
                companies.Add(company);
            }
            return companies;
        }
        public List<School> CreateSchools()
        {
            schools = new List<School>();
            var records = ReadSchools();
            var locations = ReadLocations();
            for (var i = 0; i < records.Count; i++)
            {
                var _rnd = new Random();
                var school = new School
                {
                    Id = records[i].Id,
                    Name = records[i].Name,
                    PostCode = records[i].PostCode,
                    Street = records[i].Street,
                    WebsiteUrl = records[i].WebsiteUrl,
                    LocationId = locations[Convert.ToInt32(_rnd.Next(1, locations.Count))].Id
                };
                schools.Add(school);
            }
            return schools;
        }
        public List<Recruiter> CreateRecruiters()
        {
            recruiters = new List<Recruiter>();
            IPasswordHasher<Recruiter> hasher = new PasswordHasher<Recruiter>();

            var companies = ReadCompanies();
            var locations = ReadLocations();
            var records = ReadRecruiters();
            for (var i = 0; i < records.Count; i++)
            {
                var _rnd = new Random();
                var recruiter = new Recruiter
                {
                    Id = records[i].Id,
                    FirstName = records[i].FirstName,
                    LastName = records[i].LastName,
                    UserName = records[i].FirstName + " " + records[i].LastName,
                    NormalizedUserName = (records[i].FirstName + " " + records[i].LastName).ToUpper(),
                    DateOfBirth = records[i].DateOfBirth,
                    PhoneNumber = records[i].PhoneNumber,
                    Email = records[i].Email,
                    NormalizedEmail = records[i].Email.ToUpper(),
                    EmailConfirmed = true,
                    LocationId = locations[Convert.ToInt32(_rnd.Next(1, locations.Count))].Id,
                    ImageUrl = "https://thispersondoesnotexist.com/image",
                    CompanyId = companies[Convert.ToInt32(_rnd.Next(1, companies.Count))].Id,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    IsRecruiter = true,
                    IsAdmin = false,
                    HasApprovedTermsAndConditions = true,
                };
                recruiter.PasswordHash = hasher.HashPassword(recruiter, "Test123?");
                recruiters.Add(recruiter);
            }
            return recruiters;
        }

        public List<Student> CreateStudents()
        {
            students = new List<Student>();
            IPasswordHasher<Student> hasher = new PasswordHasher<Student>();
            var records = ReadStudents();
            var schools = ReadSchools();
            var locations = ReadLocations();
            var jobs = CreateJobs();
            for (var i = 0; i < records.Count; i++)
            {
                var _rnd = new Random();
                var student = new Student
                {
                    Id = records[i].Id,
                    FirstName = records[i].FirstName,
                    LastName = records[i].LastName,
                    UserName = records[i].FirstName + " " + records[i].LastName,
                    NormalizedUserName = (records[i].FirstName + " " + records[i].LastName).ToUpper(),
                    DateOfBirth = records[i].DateOfBirth,
                    PhoneNumber = records[i].PhoneNumber,
                    Email = records[i].Email,
                    NormalizedEmail = records[i].Email.ToUpper(),
                    EmailConfirmed = true,
                    LocationId = locations[Convert.ToInt32(_rnd.Next(1, locations.Count))].Id,
                    ImageUrl = "https://thispersondoesnotexist.com/image",
                    SchoolId = schools[Convert.ToInt32(_rnd.Next(1, schools.Count))].Id,
                    JobId = jobs[Convert.ToInt32(_rnd.Next(1, jobs.Count))].Id,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    IsRecruiter = false,
                    IsAdmin = false,
                    HasApprovedTermsAndConditions = true,

                };
                student.PasswordHash = hasher.HashPassword(student, "Test123?");
                students.Add(student);
            }
            return students;
        }
        public List<Job> CreateJobs()
        {
            jobs = new List<Job>
            {
                new Job
                {
                    Id = "95b17610-ed08-47de-9a9a-991ec36f1766",
                    Name = "Computer Systems Analyst"
                },
                new Job
                {
                    Id = "adf2b66f-7135-4e9c-8a8d-08f62a0a8362",
                    Name = "Web Designer"
                },
                new Job
                {
                    Id = "677051c0-683f-4215-b146-991bdd736d3e",
                    Name = "Systems Administrator"
                },
                new Job
                {
                    Id = "32911569-b4ff-45e5-b093-1eb54facf9a8",
                    Name = "Systems Administrator"
                },
                new Job
                {
                    Id = "c7887c2c-608a-4912-9fe9-afa4ad2b13ae",
                    Name = "Backend Developer"
                },
                new Job
                {
                    Id = "04803f55-1c3e-44d7-95fe-b33516f0de68",
                    Name = "Frontend Developer"
                },
                new Job
                {
                    Id = "c564ad58-cd3d-4f57-a624-0292b4bbcab2",
                    Name = "Help Desk Technician"
                },
                new Job
                {
                    Id = "65ea31fe-8415-4ec0-aa2e-b90f31604616",
                    Name = "Fullstack Developer"
                },
                new Job
                {
                    Id = "d55a54b9-011f-4303-a626-ff51604ad1ce",
                    Name = "Software Engineer"
                },
                new Job
                {
                    Id = "3ccb4ea0-cdfa-4a9a-826a-f53e69c257fe",
                    Name = "Database Administrator"
                },
                new Job
                {
                    Id = "0da52a42-2429-4eeb-bc41-4aa89ab99c5c",
                    Name = "Help Desk Operator"
                },
                new Job
                {
                    Id = "ad7a677a-5144-42cc-8574-7685cadd8efa",
                    Name = "Python Developer"
                },
                new Job
                {
                    Id = "0f3274f9-776a-4ffc-9bed-baaf7c7d8123",
                    Name = "Java Developer"
                },
                new Job
                {
                    Id = "43858f58-1bac-4513-9ce7-1a5b2bfe5336",
                    Name = "C++ Developer"
                },
                new Job
                {
                    Id = "5dd595b8-bdfb-489f-93d7-3ea348c9a7d0",
                    Name = "C Developer"
                },
                new Job
                {
                    Id = "c1cd98d3-4ba3-4aa8-8ac1-ecc2fa1bc6b9",
                    Name = "Application Developer"
                },
                new Job
                {
                    Id = "3aade377-097e-4e26-a4b3-00d4dafac1fe",
                    Name = "Systems Software Developer"
                },
                new Job
                {
                    Id = "4287622a-a542-4c64-90bb-fa033e56e199",
                    Name = "QA Engineer"
                },
                new Job
                {
                    Id = "298f93e6-d626-4018-b3c3-78dac79ec71d",
                    Name = "Security Engineer"
                },
                new Job
                {
                    Id = "b9359feb-d1ac-4a3a-ab6a-473fd9daf467",
                    Name = "DevOps Engineer"
                },
                new Job
                {
                    Id = "049e5aed-9548-4642-8be1-5d60fec74547",
                    Name = "Blockchain Engineer"
                },
                new Job
                {
                    Id = "2cf958cd-4806-4308-8220-ca7ec5e75fc7",
                    Name = "Software Architect"
                },
                new Job
                {
                    Id = "1275e3d2-2dd6-4762-b1bc-ac025b833ecf",
                    Name = ".Net Developer"
                },
                new Job
                {
                    Id = "5c5c1739-56e8-47e3-adfd-fda1bd0766c3",
                    Name = "PHP Developer"
                },
                new Job
                {
                    Id = "85a56c5c-eeff-48bc-87c1-91dbfa727363",
                    Name = "Javascript Developer"
                },
                new Job
                {
                    Id = "767205cf-e154-4919-82a3-0ab8f0ba4370",
                    Name = "Ruby Developer"
                },
                new Job
                {
                    Id = "79d52d29-caaa-40c1-9ffa-6d7b6f2c377d",
                    Name = "UI Designer"
                },
                new Job
                {
                    Id = "78274469-e984-4960-a392-eaded7274fa3",
                    Name = "Support Specialist"
                },
                new Job
                {
                    Id = "77e5b7cf-a2ec-4e73-b8ae-8599b03f8732",
                    Name = "Computer Programmer"
                },
                new Job
                {
                    Id = "cb11b5c1-173d-4d05-a247-381bd9acfc2e",
                    Name = "Web Developer"
                },
                new Job
                {
                    Id = "d295e325-ea5f-4932-b7e3-e52cfa203ccd",
                    Name = "IT Technician"
                },
                new Job
                {
                    Id = "7614cdf5-37f8-4ec7-9b80-674bbb6dcfc3",
                    Name = "Data Scientist"
                },
                new Job
                {
                    Id = "d0ef77af-ed9c-46a3-8dda-b751af3fac9f",
                    Name = "Data Analyst"
                },
                new Job
                {
                    Id = "25a8998c-5ab7-4b25-8f7e-5183d6bdbac5",
                    Name = "Data Engineer"
                },
                new Job
                {
                    Id = "95d5e79e-cad6-4ce8-877d-ceaaebf072ef",
                    Name = "UX Designer"
                },
                new Job
                {
                    Id = "0893025e-6cd1-49b3-8fda-082c15ab8979",
                    Name = "Cloud System Engineer"
                }
            };
            return jobs;
        }

        public List<Location> CreateLocations()
        {
            locations = new List<Location>();
            var records = ReadLocations();
            for (var i = 0; i < records.Count; i++)
            {
                var _rnd = new Random();
                var location = new Location
                {
                    Id = records[i].Id,
                    Continent = records[i].Continent,
                    Country = records[i].Country,
                    City = records[i].City
                };
                locations.Add(location);
            }
            return locations;
        }
        public List<Match> CreateMatches()
        {
            matches = new List<Match>();
            for (var i = 0; i < students.Count; i++)
            {
                var student = students[i];
                var match = new Match
                {
                    Id = Guid.NewGuid().ToString(),
                    StudentId = student.Id,
                    RecruiterId = recruiters[i].Id,
                    CreateDate = RandomDay()
                };
                matches.Add(match);
            }

            return matches;
        }

        public List<Vacancy> CreateVacancies()
        {
            vacancies = new List<Vacancy>();
            var recruiters = ReadRecruiters();
            var jobs = CreateJobs();
            for (var i = 0; i < recruiters.Count; i++)
            {
                var _rnd = new Random();
                var vacancy = new Vacancy
                {
                    Id = Guid.NewGuid().ToString(),
                    JobId = jobs[Convert.ToInt32(_rnd.Next(1, jobs.Count))].Id,
                    RecruiterId = recruiters[i].Id,
                    Name = jobs[Convert.ToInt32(_rnd.Next(1, jobs.Count))].Name,
                };
                vacancies.Add(vacancy);
            }
            return vacancies;
        }

        public List<Company> ReadCompanies()
        {
            string basePath = Environment.CurrentDirectory;
            string relativePath = "/st-2122-1-S3-project-jbmaene1998/src/Imi.Project.Api.Infrastructure/Data/CsvFiles/Companies.csv";

            for (int i = 0; i < 3; i++)
            {
                basePath = Path.GetDirectoryName(basePath);
            }

            
            List<Company> records;
            using (var streamReader = new StreamReader($"{basePath}{relativePath}"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<CompanyClassMap>();
                    records = csvReader.GetRecords<Company>().ToList();
                }
            }
            return records;
        }
        public List<Location> ReadLocations()
        {
            string basePath = Environment.CurrentDirectory;
            string relativePath = "/st-2122-1-S3-project-jbmaene1998/src/Imi.Project.Api.Infrastructure/Data/CsvFiles/Locations.csv";

            for (int i = 0; i < 3; i++)
            {
                basePath = Path.GetDirectoryName(basePath);
            }

            List<Location> records;
            using (var streamReader = new StreamReader($"{basePath}{relativePath}"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<LocationClassMap>();
                    records = csvReader.GetRecords<Location>().ToList();
                }
            }
            return records;
        }
        public List<Recruiter> ReadRecruiters()
        {
            string basePath = Environment.CurrentDirectory;
            string relativePath = "/st-2122-1-S3-project-jbmaene1998/src/Imi.Project.Api.Infrastructure/Data/CsvFiles/Recruiters.csv";

            for (int i = 0; i < 3; i++)
            {
                basePath = Path.GetDirectoryName(basePath);
            }

            
            List<Recruiter> records;
            using (var streamReader = new StreamReader($"{basePath}{relativePath}"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<RecruiterClassMap>();
                    records = csvReader.GetRecords<Recruiter>().ToList();
                }
            }
            return records;
        }
        public List<School> ReadSchools()
        {
            string basePath = Environment.CurrentDirectory;
            string relativePath = "/st-2122-1-S3-project-jbmaene1998/src/Imi.Project.Api.Infrastructure/Data/CsvFiles/Schools.csv";

            for (int i = 0; i < 3; i++)
            {
                basePath = Path.GetDirectoryName(basePath);
            }

            List<School> records;
            using (var streamReader = new StreamReader($"{basePath}{relativePath}"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<SchoolClassMap>();
                    records = csvReader.GetRecords<School>().ToList();
                }
            }
            return records;
        }
        public List<Student> ReadStudents()
        {
            string basePath = Environment.CurrentDirectory;
            string relativePath = "/st-2122-1-S3-project-jbmaene1998/src/Imi.Project.Api.Infrastructure/Data/CsvFiles/Students.csv";

            for (int i = 0; i < 3; i++)
            {
                basePath = Path.GetDirectoryName(basePath);
            }

            List<Student> records;
            using (var streamReader = new StreamReader($"{basePath}{relativePath}"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<StudentClassMap>();
                    records = csvReader.GetRecords<Student>().ToList();
                }
            }
            return records;
        }

        public DateTime RandomDay()
        { 
            var gen = new Random();
            var start = new DateTime(2010, 1, 1);
            var range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        public List<Like> CreateLikes()
        {
            likes = new List<Like>();
            var students = ReadStudents();
            var recruiters = ReadRecruiters();
            for (var i = 0; i < students.Count; i++)
            {
                var _rnd = new Random();
                var like = new Like
                {
                    IsRecruiter = _rnd.Next(1000) <= 200 ? true : false,
                    RecruiterId = recruiters[i].Id,
                    StudentId = recruiters[i].Id
                };
                likes.Add(like);
            }
            return likes;
        }
    }
}
