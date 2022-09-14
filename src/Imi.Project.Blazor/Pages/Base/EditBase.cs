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
    public class EditBase : ComponentBase
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

        public EditBase()
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
            var recruiter = await _recruiterService.GetById(LoginState.Id);
            var student = await _studentService.GetById(LoginState.Id);
            if (student != null)
            {
                student.Location = await _apiLocationService.GetLocationById(student.LocationId);
                student.Job = await _apiJobService.Get(student.JobId);
                student.School = await _apiSchoolService.GetSchoolById(student.SchoolId);
                currentStudent = student.MapToEntity();
            }
            else if (recruiter != null)
            {
                currentRecruiter = recruiter.MapToEntity();
            }
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
            if (currentRecruiter.Id is null)
            {
                dtos = await _apiSearchService.SearchLocation("Europe", "Belgium", currentStudent.CitySearchText);
            }
            else
            {
                dtos = await _apiSearchService.SearchLocation("Europe", "Belgium", currentRecruiter.CitySearchText);
            }
            if (dtos != null)
            {
                foreach (var item in dtos)
                {
                    locations.Add(item.MapToEntity());
                }
            }
            StateHasChanged();
        }

        public async void OnJobInput()
        {
            jobs = null;
            jobs = new List<Job>();
            var dtos = await _apiSearchService.SearchJob(currentStudent.JobSearchText);
            if (dtos != null)
            {
                foreach (var item in dtos)
                {
                    jobs.Add(item.MapToEntity());
                }
            }
            StateHasChanged();
        }

        public async void OnCompanyInput()
        {
            companies = null;
            companies = new List<Company>();
            var dtos = await _apiSearchService.SearchCompany(currentRecruiter.CompanySearchText);
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
            await _studentService.Update(currentStudent.MapToDto());
        }

        public async void RecruiterSave()
        {
            await _recruiterService.Update(currentRecruiter.MapToDto());
        }
    }
}
 
