using FreshMvvm;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Mobile.Core;
using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Domain.Interfaces.Api;
using Imi.Project.Mobile.Core.Domain.Mapper;
using Imi.Project.Mobile.Core.Domain.Services.Api;
using Imi.Project.Mobile.Core.Domain.Services.Mocking;
using Imi.Project.Mobile.Core.Modals;
using MLToolkit.Forms.SwipeCardView.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class RecruiterHomeViewModel : FreshBasePageModel
    {
        public RecruiterHomeViewModel(IApiStudentService studentService, IApiJobService jobService, IApiSchoolService schoolService, IApiLocationService locationService, IApiLikeService likeService
            )
        {
            _studentService = studentService;
            _jobService = jobService;
            _locationService = locationService;
            _schoolService = schoolService;
            _likeService = likeService;

        }
        #region OverrideMethods
        public async override void Init(object initData)
        {
            base.Init(initData);
            LoadCards();
        }
        #endregion
        #region Properties
        private readonly IApiStudentService _studentService;
        private readonly IApiJobService _jobService;
        private readonly IApiLocationService _locationService;
        private readonly IApiLikeService _likeService;
        private readonly IApiSchoolService _schoolService;
        public ObservableCollection<Student> Students { get; set; }
        #endregion
        #region Commands
        public ICommand OpenSettings => new Command(
            async () => await CoreMethods.PushPageModel<RecruiterSettingsViewModel>(null, false, true)
            );
        public ICommand OpenMatches => new Command(
            async () => await CoreMethods.PushPageModel<RecruiterMatchViewModel>(null, false, true)
            );
        public ICommand OnSwiped => new Command<SwipedCardEventArgs>(
            (SwipedCardEventArgs e) => Swipe(e));
        #endregion
        #region Methods
        public async void Swipe(SwipedCardEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeCardDirection.None:
                    break;
                case SwipeCardDirection.Right:
                    var swipedUserId = (e.Item as Student).Id;
                    var dto = new LikeRequestDto()
                    {
                        Id = Guid.NewGuid().ToString(),
                        RecruiterId = swipedUserId,
                        StudentId = LoginState.Id,
                        IsRecruiter = true
                    };
                    await _likeService.Add(dto);
                    var likesFromRecruiter = await _likeService.GetAllFromStudent(swipedUserId);
                    foreach (var like in likesFromRecruiter)
                    {
                        if (like.RecruiterId == LoginState.Id)
                        {
                            await CoreMethods.DisplayAlert("Match", "You have a match", "I understand");
                        }
                    }
                    break;
                case SwipeCardDirection.Left:
                    break;
                case SwipeCardDirection.Up:
                    break;
                case SwipeCardDirection.Down:
                    break;
            }
        }

        private async void LoadCards()
        {
            try
            {
                Students = new ObservableCollection<Student>();

                var list = await _studentService.GetPotentialStudents(LoginState.Id);
                foreach (var student in list)
                {
                    student.Job = await _jobService.Get(student.JobId);
                    student.Location = await _locationService.GetLocationById(student.LocationId);
                    student.School = await _schoolService.GetSchoolById(student.SchoolId);
                    Students.Add(student.MapToEntity());
                }
                RaisePropertyChanged(nameof(Students));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
