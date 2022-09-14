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
    public class HomeBase : ComponentBase
    {
        public Recruiter selectedRecruiter;
        public Student selectedStudent;
        public IEnumerable<Recruiter> recruiters;
        public IEnumerable<Student> students;
        private readonly IApiStudentService _studentService;
        private readonly IApiRecruiterService _recruiterService;
        public Student currentStudent;
        public Recruiter currentRecruiter;

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        public HomeBase()
        {
            _recruiterService = new ApiRecruiterService();
            _studentService = new ApiStudentService();
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
            if (currentRecruiter is null)
            {
                
                await ShowRecruiters();
            }
            else if (currentStudent is null)
            {
                await ShowStudents();
            }
        }

        public async Task ShowRecruiters()
        {
            var results = await _recruiterService.GetPotentialRecruiters(LoginState.Id);
            List<Recruiter> mappedResults = new List<Recruiter>();
            foreach (var recruiter in results)
            {
                mappedResults.Add(recruiter.MapToEntity());
            }
            recruiters = new List<Recruiter>();
            recruiters = mappedResults;
        }
        public async Task ShowStudents()
        {
            var results = await _studentService.GetPotentialStudents(LoginState.Id);
            List<Student> mappedResults = new List<Student>();
            foreach (var student in results)
            {
                mappedResults.Add(student.MapToEntity());
            }
            students = new List<Student>();
            students = mappedResults;
        }

        public void Dislike()
        {
            throw new NotImplementedException();
        }

        public void Like()
        {
            throw new NotImplementedException();
        }
        public void Detail(BasePerson person)
        {
            if (person is Recruiter)
            {
                selectedRecruiter = person as Recruiter;
            }
            else
            {
                selectedStudent = person as Student;
            }
        }
        public void GoBack()
        {
            NavigationManager.NavigateTo($"/home", forceLoad: true);
        }
    }

}
