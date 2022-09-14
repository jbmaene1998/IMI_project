using FreshMvvm;
using Imi.Project.Mobile.Core.Domain.Interfaces.Api;
using Imi.Project.Mobile.Core.Domain.Services.Api;
using Imi.Project.Mobile.Core.Domain.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using Imi.Project.Mobile.Core.Modals;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class RecruiterDetailViewModel : FreshBasePageModel
    {
        public RecruiterDetailViewModel(string recruiterId, IApiRecruiterService recruiterService)
        {
            _recruiterService = recruiterService;
            Recruiter = new Recruiter();
            Recruiter.Id = recruiterId;
            LoadDetails();
        }
        #region OverrideMethods
        public override void Init(object initData)
        {
            base.Init(initData);
        }
        #endregion
        #region Properties
        public Recruiter Recruiter { get; set; }
        private readonly IApiRecruiterService _recruiterService;
        #endregion
        #region Commands
        public ICommand OpenSettings => new Command(
            async () => await CoreMethods.PushPageModel<StudentSettingsViewModel>(null, false, true)
            );
        public ICommand GoHome => new Command(
            async () => await CoreMethods.PushPageModel<StudentHomeViewModel>(null, false, true)
            );
        #endregion
        #region Methods
        private async void LoadDetails()
        {
            Recruiter = (await _recruiterService.GetById(Recruiter.Id)).MapToEntity();
            RaisePropertyChanged(nameof(Recruiter));
        }
        #endregion
    }
}
