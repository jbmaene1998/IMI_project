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
    public class MatchesBase : ComponentBase
    {
        public Recruiter selectedRecruiter;
        public Student selectedStudent;
        public List<Match> matches;
        private readonly IApiStudentService _studentService;
        private readonly IApiRecruiterService _recruiterService;
        private readonly IApiLocationService _apiLocationService;
        private readonly IApiSchoolService _apiSchoolService;
        private readonly IApiJobService _apiJobService;
        private readonly IApiMatchService _matchService;
        public IEnumerable<Recruiter> recruiters;
        public IEnumerable<Student> students;
        public Student currentStudent;
        public Recruiter currentRecruiter;

        public Student CurrentStudent { get; set; }
        public Recruiter CurrentRecruiter { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        public MatchesBase()
        {
            _recruiterService = new ApiRecruiterService();
            _studentService = new ApiStudentService();
            _apiLocationService = new ApiLocationService();
            _apiSchoolService = new ApiSchoolService();
            _apiJobService = new ApiJobService();
            _matchService = new ApiMatchService();
        }
        protected override async Task OnInitializedAsync()
        {
            var recruiters = await _recruiterService.GetPotentialRecruiters(LoginState.Id);
            var students = await _studentService.GetPotentialStudents(LoginState.Id);
            if (recruiters != null)
            {
                currentStudent = _studentService.GetById(LoginState.Id).Result.MapToEntity();
            }
            else if (students != null)
            {
                currentRecruiter = _recruiterService.GetById(LoginState.Id).Result.MapToEntity();
            }
            var matchesForRecruiter = await _matchService.GetAllByRecruiter(LoginState.Id);
            var matchesForStudents = await _matchService.GetAllByStudent(LoginState.Id);

            if (matchesForRecruiter != null)
            {
                foreach (var item in matchesForRecruiter)
                {
                    Match mappedItem = item.MapToEntity();
                    mappedItem.Student = _studentService.GetById(item.StudentId).Result.MapToEntity();
                    matches = new List<Match>();
                    matches.Add(mappedItem);
                }
            }
            else
            {
                foreach (var item in matchesForStudents)
                {
                    Match mappedItem = item.MapToEntity();
                    mappedItem.Recruiter = _recruiterService.GetById(item.RecruiterId).Result.MapToEntity();
                    matches = new List<Match>();
                    matches.Add(mappedItem);
                }
            }
            Console.WriteLine("error. homebase.cs line 54");
        }


        public void Detail(string id)
        {
            if (LoginState.IsRecruiter)
            {
                selectedStudent = _studentService.GetById(id).Result.MapToEntity();
            }
            else
            {
                selectedRecruiter = _recruiterService.GetById(id).Result.MapToEntity();
            }
        }
        public void GoBack()
        {
            NavigationManager.NavigateTo($"/matches", forceLoad: true);
        }
    }
}