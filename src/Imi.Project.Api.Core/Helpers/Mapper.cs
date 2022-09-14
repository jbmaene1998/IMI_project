using System;
using Microsoft.AspNetCore.Http;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Helper;

namespace Imi.Project.Api.Core.Helpers
{
    public class Mapper : IMapper
    {
        public Company DtoMapper(CompanyRequestDto requestDto)
        {
            var company = new Company()
            {
                Id = requestDto.Id,
                Name = requestDto.Name,
                WebsiteUrl = requestDto.WebsiteUrl,
                Street = requestDto.Street,
                PostCode = requestDto.PostCode,
                LocationId = requestDto.LocationId
            };

            return company;
        }

        public CompanyResponseDto DtoMapper(Company entity)
        {
            CompanyResponseDto responseDto;
            if (entity is null)
            {
                return null;
            }
            
            if (entity.Location == null)
            {
                responseDto = new CompanyResponseDto()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    WebsiteUrl = entity.WebsiteUrl,
                    Street = entity.Street,
                    PostCode = entity.PostCode,
                    LocationId = entity.LocationId
                };
            }
            else
            {
                responseDto = new CompanyResponseDto()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    WebsiteUrl = entity.WebsiteUrl,
                    Street = entity.Street,
                    PostCode = entity.PostCode,
                    LocationId = entity.LocationId,
                    Location = new LocationResponseDto()
                    {
                        Id = entity.Location.Id,
                        Continent = entity.Location.Continent,
                        Country = entity.Location.Country,
                        City = entity.Location.City
                    }
                };
            }

            return responseDto;
        }

        public Job DtoMapper(JobRequestDto requestDto)
        {
            var job = new Job()
            {
                Name = requestDto.Name,
                Id = requestDto.Id
            };
            return job;
        }

        public JobResponseDto DtoMapper(Job entity)
        {
            if (entity is null)
            {
                return null;
            }
            var responseDto = new JobResponseDto()
            {
                Name = entity.Name,
                Id = entity.Id
            };
            return responseDto;
        }

        public LikeResponseDto DtoMapper(Like entity)
        {
            var responseDto = new LikeResponseDto()
            {
                RecruiterId = entity.RecruiterId,
                StudentId = entity.StudentId,
                IsRecruiter = entity.IsRecruiter
            };
            return responseDto;
        }

        public Location DtoMapper(LocationRequestDto requestDto)
        {
            var location = new Location()
            {
                Id = requestDto.Id,
                City = requestDto.City,
                Country = requestDto.Country,
                Continent = requestDto.Continent
            };
            return location;
        }

        public LocationResponseDto DtoMapper(Location entity)
        {
            if (entity is null)
            {
                return null;
            }
            var responseDto = new LocationResponseDto()
            {
                Id = entity.Id,
                City = entity.City,
                Country = entity.Country,
                Continent = entity.Continent
            };
            return responseDto;
        }

        public LocationResponseDto DtoMapper(dynamic locationInput)
        {
            if (locationInput is Location)
            {
                DtoMapper(locationInput);
            }
            var responseDto = new LocationResponseDto()
            {
                Output = locationInput
            };
            return responseDto;
        }

        public Match DtoMapper(MatchRequestDto requestDto)
        {
            var match = new Match()
            {
                Id = requestDto.Id,
                StudentId = requestDto.StudentId,
                RecruiterId = requestDto.RecruiterId,
                CreateDate = DateTime.Now
            };
            return match;
        }

        public MatchResponseDto DtoMapper(Match entity)
        {
            if (entity is null)
            {
                return null;
            }
            var responseDto = new MatchResponseDto()
            {
                Id = entity.Id,
                RecruiterId = entity.RecruiterId,
                StudentId = entity.StudentId,
                CreateDate = entity.CreateDate
            };
            return responseDto;
        }

        public Message DtoMapper(MessageRequestDto requestDto)
        {
            var message = new Message()
            {
                Id = requestDto.Id,
                FromId = requestDto.FromId,
                ToId = requestDto.ToId,
                TextMessage = requestDto.TextMessage,
                DateTimeMessage = DateTime.Now
            };
            return message;
        }

        public MessageResponseDto DtoMapper(Message entity)
        {
            if (entity is null)
            {
                return null;
            }
            var responseDto = new MessageResponseDto
            {
                Id = entity.Id,
                FromId = entity.FromId,
                ToId = entity.ToId,
                TextMessage = entity.TextMessage,
                DateTimeMessage = entity.DateTimeMessage
            };
            return responseDto;
        }

        private static string GetFullImageUrl(string image)
        {
            if (string.IsNullOrEmpty(image))
            {
                return null;
            }

            var httpContextAccessor = new HttpContextAccessor();

            var scheme = httpContextAccessor.HttpContext.Request.Scheme;
            var url = httpContextAccessor.HttpContext.Request.Host.Value;

            var fullImageUrl = $"{scheme}://{url}/{image.Replace("\\", "/")}";

            return fullImageUrl;
        }

        public Recruiter DtoMapper(RecruiterRequestDto requestDto)
        {
            var recruiter = new Recruiter()
            {
                Id = requestDto.Id,
                FirstName = requestDto.FirstName,
                LastName = requestDto.LastName,
                UserName = requestDto.FirstName + " " + requestDto.LastName,
                NormalizedUserName = (requestDto.FirstName + requestDto.LastName).ToUpper(),
                PhoneNumber = requestDto.PhoneNumber,
                Email = requestDto.Email,
                DateOfBirth = requestDto.DateOfBirth,
                ImageUrl = requestDto.ImageUrl,
                LocationId = requestDto.LocationId,
                CompanyId = requestDto.CompanyId
            };
            return recruiter;
        }

        public RecruiterResponseDto DtoMapper(Recruiter entity)
        {
            if (entity is null)
            {
                return null;
            }
            RecruiterResponseDto recruiterResponseDto;
            if (entity.Company is null || entity.Location is null)
            {
                recruiterResponseDto = new RecruiterResponseDto()
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    PhoneNumber = entity.PhoneNumber,
                    Email = entity.Email,
                    DateOfBirth = entity.DateOfBirth,
                    ImageUrl = entity.ImageUrl,
                    CompanyId = entity.CompanyId,
                    LocationId = entity.LocationId,
                    IsAdmin = entity.IsAdmin,
                    IsRecruiter = entity.IsRecruiter,
                };
            }
            else
            {
                recruiterResponseDto = new RecruiterResponseDto()
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    PhoneNumber = entity.PhoneNumber,
                    Email = entity.Email,
                    DateOfBirth = entity.DateOfBirth,
                    ImageUrl = entity.ImageUrl,
                    CompanyId = entity.CompanyId,
                    LocationId = entity.LocationId,
                    IsRecruiter =entity.IsRecruiter,
                    IsAdmin =entity.IsAdmin,
                    Company = new CompanyResponseDto()
                    {
                        Id = entity.Id,
                        Name = entity.Company.Name,
                        WebsiteUrl = entity.ImageUrl,
                        Street = entity.Company.Street,
                        LocationId = entity.LocationId,
                    },
                    Location = new LocationResponseDto()
                    {
                        Id = entity.Location.Id,
                        Continent = entity.Location.Continent ?? "Empty",
                        Country = entity.Location.Country ?? "Empty",
                        City = entity.Location.City ?? "Empty"
                    }
                };
            }


            return recruiterResponseDto;
        }

        public RecruiterRequestDto DtoMapper(RecruiterResponseDto responseDto)
        {
            var recruiterRequestDto = new RecruiterRequestDto
            {
                Id = responseDto.Id,
                FirstName = responseDto.FirstName,
                LastName = responseDto.LastName,
                PhoneNumber = responseDto.PhoneNumber,
                Email = responseDto.Email,
                DateOfBirth = responseDto.DateOfBirth,
                ImageUrl = responseDto.ImageUrl,
                LocationId = responseDto.LocationId,
                CompanyId = responseDto.CompanyId
            };
            return recruiterRequestDto;
        }

        public Student DtoMapper(StudentRequestDto requestDto)
        {
            var student = new Student
            {
                Id = requestDto.Id,
                FirstName = requestDto.FirstName,
                LastName = requestDto.LastName,
                UserName = requestDto.FirstName + " " + requestDto.LastName,
                NormalizedUserName = (requestDto.FirstName + requestDto.LastName).ToUpper(),
                PhoneNumber = requestDto.PhoneNumber,
                Email = requestDto.Email,
                DateOfBirth = requestDto.DateOfBirth,
                ImageUrl = requestDto.ImageUrl,
                LocationId = requestDto.LocationId,
                SchoolId = requestDto.SchoolId
            };
            return student;
        }

        public StudentResponseDto DtoMapper(Student entity)
        {
            if (entity is null)
            {
                return null;
            }
            StudentResponseDto studentResponseDto;
            if (entity.School is null || entity.Location is null || entity.Job is null)
            {
                studentResponseDto = new StudentResponseDto()
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    PhoneNumber = entity.PhoneNumber,
                    Email = entity.Email,
                    DateOfBirth = entity.DateOfBirth,
                    ImageUrl = entity.ImageUrl,
                    SchoolId = entity.SchoolId,
                    LocationId = entity.LocationId,
                    JobId = entity.JobId
                };
            }
            else
            {
                studentResponseDto = new StudentResponseDto()
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    PhoneNumber = entity.PhoneNumber,
                    Email = entity.Email,
                    DateOfBirth = entity.DateOfBirth,
                    ImageUrl = entity.ImageUrl,
                    SchoolId = entity.SchoolId,
                    LocationId = entity.LocationId,
                    JobId = entity.JobId,
                    Job = new JobResponseDto()
                    {
                        Id = entity.Job.Id,
                        Name = entity.Job.Name
                    },
                    School = new SchoolResponseDto()
                    {
                        Id = entity.Id,
                        Name = entity.School.Name,
                        WebsiteUrl = entity.ImageUrl,
                        Street = entity.School.Street,
                        LocationId = entity.LocationId,
                        Location = new LocationResponseDto()
                        {
                            Id = entity.School.Location.Id,
                            Continent = entity.School.Location.Continent ?? "Empty",
                            Country = entity.School.Location.Country ?? "Empty",
                            City = entity.School.Location.City ?? "Empty"
                        }
                    },
                    Location = new LocationResponseDto()
                    {
                        Id = entity.Location.Id,
                        Continent = entity.Location.Continent ?? "Empty",
                        Country = entity.Location.Country ?? "Empty",
                        City = entity.Location.City ?? "Empty"
                    }
                };
            }

            return studentResponseDto;
        }

        public StudentRequestDto DtoMapper(StudentResponseDto responseDto)
        {
            var requestDto = new StudentRequestDto
            {
                Id = responseDto.Id,
                FirstName = responseDto.FirstName,
                LastName = responseDto.LastName,
                PhoneNumber = responseDto.PhoneNumber,
                Email = responseDto.Email,
                DateOfBirth = responseDto.DateOfBirth,
                ImageUrl = responseDto.ImageUrl,
                LocationId = responseDto.LocationId,
                SchoolId = responseDto.SchoolId,
                JobId = responseDto.JobId,
            };
            return requestDto;
        }

        public School DtoMapper(SchoolRequestDto requestDto)
        {
            var entity = new School()
            {
                Id = requestDto.Id,
                Name = requestDto.Name,
                WebsiteUrl = requestDto.WebsiteUrl,
                Street = requestDto.Street,
                PostCode = requestDto.PostCode,
                LocationId = requestDto.LocationId
            };

            return entity;
        }

        public SchoolResponseDto DtoMapper(School entity)
        {
            if (entity is null)
            {
                return null;
            }
            var schoolResponseDto = new SchoolResponseDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                WebsiteUrl = entity.WebsiteUrl,
                Street = entity.Street,
                PostCode = entity.PostCode,
                LocationId = entity.LocationId
            };

            return schoolResponseDto;
        }

        public Vacancy DtoMapper(VacancyRequestDto requestDto)
        {
            var entity = new Vacancy()
            {
                Id = requestDto.Id,
                Name = requestDto.Name,
                JobId = requestDto.JobId,
                RecruiterId = requestDto.RecruiterId
            };
            return entity;
        }

        public VacancyResponseDto DtoMapper(Vacancy entity)
        {
            if (entity is null)
            {
                return null;
            }
            var vacancyResponseDto = new VacancyResponseDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                JobId = entity.JobId,
                RecruiterId = entity.RecruiterId
            };
            return vacancyResponseDto;
        }

        public Like DtoMapper(LikeRequestDto requestDto)
        {
            var entity = new Like()
            {
                Id = requestDto.Id,
                RecruiterId = requestDto.RecruiterId,
                StudentId = requestDto.StudentId,
                IsRecruiter = requestDto.IsRecruiter
            };
            return entity;
        }

        public Recruiter DtoMapper(RegisterRecruiterRequestDto requestDto)
        {
            var recruiter = new Recruiter()
            {
                Id = requestDto.Id,
                FirstName = requestDto.FirstName,
                LastName = requestDto.LastName,
                PhoneNumber = requestDto.PhoneNumber,
                Email = requestDto.Email,
                DateOfBirth = requestDto.DateOfBirth,
                ImageUrl = requestDto.ImageUrl,
                LocationId = requestDto.LocationId,
                CompanyId = requestDto.CompanyId,
                UserName = requestDto.FirstName + " " + requestDto.LastName,
                NormalizedUserName = (requestDto.FirstName + " " + requestDto.LastName).ToUpper(),
            };
            return recruiter;
        }

        public Student DtoMapper(RegisterStudentRequestDto requestDto)
        {
            var student = new Student
            {
                Id = requestDto.Id,
                FirstName = requestDto.FirstName,
                LastName = requestDto.LastName,
                PhoneNumber = requestDto.PhoneNumber,
                Email = requestDto.Email,
                DateOfBirth = requestDto.DateOfBirth,
                ImageUrl = requestDto.ImageUrl,
                LocationId = requestDto.LocationId,
                SchoolId = requestDto.SchoolId,
                UserName = requestDto.FirstName + " " + requestDto.LastName,
                NormalizedUserName = (requestDto.FirstName + " " + requestDto.LastName).ToUpper(),
            };
            return student;
        }

        public AdminResponseDto DtoMapper(Admin entity)
        {
            var responseDto = new AdminResponseDto
            {
                Id = entity.Id,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
            };
            return responseDto;
        }
    }
}
