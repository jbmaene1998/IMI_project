using Imi.Project.Api.Core.Dtos;
using Imi.Project.Blazor.Core;
using Imi.Project.Blazor.Core.Interfaces;
using Imi.Project.Blazor.Core.Mapper;
using Imi.Project.Blazor.Core.Modals;
using Imi.Project.Blazor.Core.Services;
using Imi.Project.Blazor.CoreModals.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Pages.Base
{
    public class CreateBase : ComponentBase
    {
        public Recruiter recruiter;
        public Student student;
        private readonly IApiStudentService _studentService;
        private readonly IApiRecruiterService _recruiterService;
        private readonly IApiLocationService _apiLocationService;
        private readonly IApiSchoolService _apiSchoolService;
        private readonly IApiJobService _apiJobService;
        private readonly IApiSearchService _apiSearchService;
        public Student currentStudent;
        public Recruiter currentRecruiter;
        public List<School> schools;
        public List<Location> locations;
        public List<Job> jobs;
        public List<Company> companies;

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        public CreateBase()
        {
            _recruiterService = new ApiRecruiterService();
            _studentService = new ApiStudentService();
            _apiLocationService = new ApiLocationService();
            _apiSchoolService = new ApiSchoolService();
            _apiJobService = new ApiJobService();
            _apiSearchService = new ApiSearchService();
        }

        protected override async Task OnInitializedAsync()
        {
            recruiter = new Recruiter();
        }

        public async void OnSchoolInput()
        {
            schools = null;
            schools = new List<School>();
            var dtos = await _apiSearchService.SearchSchool(currentStudent.SchoolSearchText);
            if (dtos != null)
            {
                foreach (var item in dtos)
                {
                    schools.Add(item.MapToEntity());
                }

            }
            StateHasChanged();
        }

        public async void OnCityInput()
        {
            locations = null;
            locations = new List<Location>();
            IEnumerable<LocationResponseDto> dtos = new List<LocationResponseDto>();
            dtos = await _apiSearchService.SearchLocation("Europe", "Belgium", recruiter.CitySearchText);
            if (dtos != null)
            {
                foreach (var item in dtos)
                {
                    locations.Add(item.MapToEntity());
                }
            }
            StateHasChanged();
        }


        public async void OnCompanyInput()
        {
            companies = null;
            companies = new List<Company>();
            var dtos = await _apiSearchService.SearchCompany(recruiter.CompanySearchText);
            if (dtos != null)
            {
                foreach (var item in dtos)
                {
                    companies.Add(item.MapToEntity());
                }
            }
            StateHasChanged();
        }

        public async void StudentSave()
        {
            await _studentService.Add(currentStudent.MapToRegisterDto());
        }

        public async void RecruiterSave()
        {
            var dto = new RegisterRecruiterRequestDto()
            {
                Id = Guid.NewGuid().ToString(),
                LastName = recruiter.LastName,
                FirstName = recruiter.FirstName,
                DateOfBirth = DateTime.Now,
                PhoneNumber = recruiter.Phone,
                Email = recruiter.Email,
                Password = "Ikbenrecruiter_2020",
                ImageUrl = "https://thispersondoesnotexist.com/image",
                CompanyId = recruiter.CompanyId,
                LocationId = recruiter.LocationId,
                ConfirmPassword = "Ikbenrecruiter_2020"
            };
            var test = await _recruiterService.Add(dto);
        }
    }
}


