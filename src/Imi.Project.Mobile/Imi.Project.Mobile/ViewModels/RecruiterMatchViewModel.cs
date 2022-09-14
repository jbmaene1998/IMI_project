using FreshMvvm;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Mobile.Core;
using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Domain.Interfaces.Api;
using Imi.Project.Mobile.Core.Domain.Services.Api;
using Imi.Project.Mobile.Core.Domain.Services.Mocking;
using Imi.Project.Mobile.Core.Modals;
using MLToolkit.Forms.SwipeCardView.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Collections.Generic;
using Xamarin.Forms;
using System;

namespace Imi.Project.Mobile.ViewModels
{
    public class RecruiterMatchViewModel : FreshBasePageModel
    {
        public RecruiterMatchViewModel(IApiMatchService matchService, IApiStudentService studentService, IApiJobService jobService)
        {
            _matchService = matchService;
            _studentService = studentService;
            _jobService = jobService;
        }
        #region OverrideMethods
        public async override void Init(object initData)
        {
            base.Init(initData);
            var students = await _matchService.GetAllByRecruiter(LoginState.Id);
            List<Student> studentList = new List<Student>();
            foreach (MatchResponseDto matchdto in students)
            {
                var studentDto = _studentService.GetById(matchdto.StudentId).Result;
                var student = new Student()
                {
                    Id = studentDto.Id,
                    FirstName = studentDto.FirstName,
                    ImageUrl = studentDto.ImageUrl,
                    JobName = (await _jobService.Get(studentDto.JobId)).Name
                };
                studentList.Add(student);
            }
            Students = new ObservableCollection<Student>(studentList);
            RaisePropertyChanged("Students");
        } 
        #endregion
        #region Properties
        private readonly IApiMatchService _matchService;
        private readonly IApiStudentService _studentService;
        private readonly IApiJobService _jobService;
        public ObservableCollection<Student> Students { get; set; }
        #endregion
        #region Commands
        public ICommand OpenSettings => new Command(
            async () => await CoreMethods.PushPageModel<RecruiterSettingsViewModel>(null, false, true)
            );
        public ICommand GoHome => new Command(
            async () => await CoreMethods.PushPageModel<RecruiterHomeViewModel>(null, false, true)
            );
        public ICommand Detail => new Command<object>(
            async (object args) => await CoreMethods.PushPageModel<StudentDetailViewModel>(((Student)((Frame)args).BindingContext).Id, false, true)
            );
        #endregion
        #region Methods
        #endregion
    }
}
