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
    public class StudentHomeViewModel : FreshBasePageModel
    {
        public StudentHomeViewModel(IApiRecruiterService recruiterService, IApiJobService jobService, IApiCompanyService companyService, IApiLocationService locationService, IApiLikeService likeService)
        {
            _recruiterService = recruiterService;
            _jobService = jobService;
            _locationService = locationService;
            _companyService = companyService;
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
        private readonly IApiRecruiterService _recruiterService;
        private readonly IApiJobService _jobService;
        private readonly IApiLocationService _locationService;
        private readonly IApiCompanyService _companyService;
        private readonly IApiLikeService _likeService;
        public ObservableCollection<Recruiter> Recruiters { get; set; }
        #endregion
        #region Commands
        public ICommand OpenSettings => new Command(
            async () => await CoreMethods.PushPageModel<StudentSettingsViewModel>(null, false, true)
            );
        public ICommand OpenMatches => new Command(
            async () => await CoreMethods.PushPageModel<StudentMatchViewModel>(null, false, true)
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
                    var swipedUserId = (e.Item as Recruiter).Id;
                    var dto = new LikeRequestDto()
                    {
                        Id = Guid.NewGuid().ToString(),
                        RecruiterId = swipedUserId,
                        StudentId = LoginState.Id
                    };
                    await _likeService.Add(dto);
                    var likesFromRecruiter = await _likeService.GetAllFromRecruiter(swipedUserId);
                    foreach (var like in likesFromRecruiter)
                    {
                        if (like.StudentId == LoginState.Id)
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
                Recruiters = new ObservableCollection<Recruiter>();

                var list = await _recruiterService.GetPotentialRecruiters(LoginState.Id);
                foreach (var recruiter in list)
                {
                    recruiter.Location = await _locationService.GetLocationById(recruiter.LocationId);
                    recruiter.Company = await _companyService.GetCompanyById(recruiter.CompanyId);
                    Recruiters.Add(recruiter.MapToEntity());
                }
                RaisePropertyChanged(nameof(Recruiters));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
