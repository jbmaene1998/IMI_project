using FreshMvvm;
using Imi.Project.Mobile.Core;
using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Domain.Services.Mocking;
using Imi.Project.Mobile.Core.Domain.Mapper;
using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Imi.Project.Mobile.Core.Domain.Interfaces.Api;
using Imi.Project.Mobile.Core.Domain.Services.Api;

namespace Imi.Project.Mobile.ViewModels
{
    public class RecruiterSettingsViewModel : FreshBasePageModel
    {
        public RecruiterSettingsViewModel(IApiRecruiterService recruiterService)
        {
            _recruiterService = recruiterService;
        }
        #region OverrideMethods
        public async override void Init(object initData)
        {
            base.Init(initData);
            var dto = await _recruiterService.GetById(LoginState.Id);
            var user = dto.MapToEntity();
            ImageUrl = user.ImageUrl;
            FullName = user.FirstName + " " + user.LastName;
            RaisePropertyChanged(nameof(ImageUrl));
            RaisePropertyChanged(nameof(FullName));
        }
        #endregion
        #region Properties
        public string ImageUrl { get; set; }
        public string FullName { get; set; }
        private readonly IApiRecruiterService _recruiterService;
        #endregion
        #region Commands
        public ICommand ManageVacancies => new Command(
            async () => await CoreMethods.PushPageModel<ManageVacanciesViewModel>(null, false, true)
            );
        public ICommand LogOutProfile => new Command(
            () => LogOut()
            );
        public ICommand ManageProfile => new Command(
            async () => await CoreMethods.PushPageModel<CreateRecruiterViewModel>(_recruiterService.GetById(LoginState.Id), false, true)
            );
        public ICommand GoHome => new Command(
            async () => await CoreMethods.PushPageModel<RecruiterHomeViewModel>(null, false, true)
            );
        public ICommand OpenMatches => new Command(
            async () => await CoreMethods.PushPageModel<RecruiterMatchViewModel>(null, false, true)
            );
        #endregion 
        #region Methods
        private async void LogOut()
        {
            await CoreMethods.DisplayAlert("Alert", "You have been logged out", "Close");
            await CoreMethods.PushPageModel<LoginViewModel>(null, false, true);
            LoginState.Logout();
        }
        #endregion
    }
}
