using Imi.Project.Api.Core.Dtos;
using Imi.Project.Blazor.Core.Modals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Mapper
{
    public static class CustomMapper
    {
        public static Student MapToEntity(this StudentResponseDto dto)
        {
            return new Student
            {
                Id = dto.Id,
                JobId = dto.JobId,
                Job = new Job()
                {
                    Name = dto.Job.Name,
                    Id = dto.Job.Id
                },
                SchoolId = dto.SchoolId,
                School = new School()
                {
                    Name = dto.School.Name,
                    PostCode = dto.School.PostCode,
                    Street = dto.School.Street,
                    WebsiteUrl = dto.School.WebsiteUrl,
                    LocationId = dto.School.LocationId,
                    Location = new Location()
                    {
                        Id = dto.Location.Id,
                        Continent = dto.Location.Continent,
                        Country = dto.Location.Country,
                        City = dto.Location.City
                    },
                    Id = dto.Id
                },
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                DateOfBirth = dto.DateOfBirth,
                ImageUrl = dto.ImageUrl,
                LocationId = dto.LocationId,
                Location = new Location()
                {
                    Id = dto.Location.Id,
                    Continent = dto.Location.Continent,
                    Country = dto.Location.Country,
                    City = dto.Location.City
                },
                Phone = dto.PhoneNumber,
                Email = dto.Email
            };
        }
        public static StudentRequestDto MapToDto(this Student dto)
        {
            return new StudentRequestDto
            {
                Id = dto.Id,
                JobId = dto.JobId,
                SchoolId = dto.SchoolId,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                DateOfBirth = dto.DateOfBirth,
                ImageUrl = dto.ImageUrl,
                LocationId = dto.LocationId,
                PhoneNumber = dto.Phone,
                Email = dto.Email,
                Password = "Ikbenstudent_2020"
            };
        }

        public static RecruiterRequestDto MapToDto(this Recruiter dto)
        {
            return new RecruiterRequestDto
            {
                Id = dto.Id,
                CompanyId = dto.CompanyId,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                DateOfBirth = dto.DateOfBirth,
                ImageUrl = dto.ImageUrl,
                LocationId = dto.LocationId,
                PhoneNumber = dto.Phone,
                Email = dto.Email,
                Password = "Ikbenrecruiter_2020"
            };
        }

        public static Recruiter MapToEntity(this RecruiterResponseDto dto)
        {
            return new Recruiter
            {
                Id = dto.Id,
                CompanyId = dto.CompanyId,
                Company = new Company()
                {
                    Name = dto.Company.Name,
                    PostCode = dto.Company.PostCode,
                    Street = dto.Company.Street,
                    WebsiteUrl = dto.Company.WebsiteUrl,
                    LocationId = dto.Company.LocationId,
                    Location = new Location()
                    {
                        Id = dto.Location.Id,
                        Continent = dto.Location.Continent,
                        Country = dto.Location.Country,
                        City = dto.Location.City
                    },
                    Id = dto.Id
                },
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                DateOfBirth = dto.DateOfBirth,
                ImageUrl = dto.ImageUrl,
                LocationId = dto.LocationId,
                Location = new Location()
                {
                    Id = dto.Location.Id,
                    Continent = dto.Location.Continent,
                    Country = dto.Location.Country,
                    City = dto.Location.City
                },
                Phone = dto.PhoneNumber,
                Email = dto.Email
            };
        }
        public static Job MapToEntity(this JobResponseDto dto)
        {
            return new Job
            { 
                Name = dto.Name, 
                Id = dto.Id 
            };
        }

        public static Match MapToEntity(this MatchResponseDto dto)
        {
            return new Match
            {
                Id = dto.Id,
                StudentId = dto.StudentId,
                RecruiterId = dto.RecruiterId
            };
        }
        public static Location MapToEntity(this LocationResponseDto dto)
        {
            return new Location
            {
                Id = dto.Id,
                Continent = dto.Continent,
                Country = dto.Country,
                City = dto.City,
                Output = dto.Output,
                
            };
        }

        public static School MapToEntity(this SchoolResponseDto dto)
        {
            return new School
            {
                Name = dto.Name,
                PostCode = dto.PostCode,
                Street = dto.Street,
                WebsiteUrl = dto.WebsiteUrl,
                LocationId = dto.LocationId,
                Id = dto.Id
            };
        }

        public static Company MapToEntity(this CompanyResponseDto dto)
        {
            return new Company
            {
                Name = dto.Name,
                PostCode = dto.PostCode,
                Street = dto.Street,
                WebsiteUrl = dto.WebsiteUrl,
                LocationId = dto.LocationId,
                Id = dto.Id
            };
        }
        public static Vacancy MapToEntity(this VacancyResponseDto dto)
        {
            return new Vacancy
            {
                Id = dto.Id,
                Name = dto.Name,
                JobId = dto.JobId,
                Job = new Job()
                {
                    Name = dto.Name,
                    Id = dto.Id
                }
            };
        }
        public static VacancyRequestDto MapToDto(this Vacancy entity)
        {
            return new VacancyRequestDto
            {
                Id = entity.Id,
                Name = entity.Name,
                JobId = entity.JobId
            };
        }

        public static Vacancy MapToEntity(this VacancyRequestDto dto)
        {
            return new Vacancy
            {
                Id = dto.Id,
                Name = dto.Name,
                JobId = dto.JobId
            };
        }

        public static RegisterStudentRequestDto MapToRegisterDto(this Student entity)
        {
            return new RegisterStudentRequestDto
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                DateOfBirth = entity.DateOfBirth,
                PhoneNumber = entity.Phone,
                Email = entity.Email,
                Password = entity.Password,
                ImageUrl = entity.ImageUrl,
                SchoolId = entity.SchoolId,
                LocationId = entity.LocationId,
                JobId = entity.JobId,
                ConfirmPassword = entity.Password
            };
        }

        public static RegisterRecruiterRequestDto MapToRegisterDto(this Recruiter entity)
        {
            return new RegisterRecruiterRequestDto
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                DateOfBirth = entity.DateOfBirth,
                PhoneNumber = entity.Phone,
                Email = entity.Email,
                Password = entity.Password,
                ImageUrl = entity.ImageUrl,
                CompanyId = entity.CompanyId,
                LocationId = entity.LocationId,
                ConfirmPassword = entity.Password
            };
        }

        public static StudentRequestDto MapToEntity(this RegisterStudentRequestDto entity)
        {
            return new StudentRequestDto
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                DateOfBirth = entity.DateOfBirth,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                Password = entity.Password,
                ImageUrl = entity.ImageUrl,
                SchoolId = entity.SchoolId,
                LocationId = entity.LocationId,
                JobId = entity.JobId
            };
        }
    }
}
