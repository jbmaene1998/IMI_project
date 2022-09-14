using FreshMvvm;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Mobile.Core;
using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Domain.Interfaces.Api;
using Imi.Project.Mobile.Core.Domain.Services.Api;
using Imi.Project.Mobile.Core.Domain.Services.Mocking;
using Imi.Project.Mobile.Core.Domain.Mapper;
using Imi.Project.Mobile.Core.Modals;
using MLToolkit.Forms.SwipeCardView.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Collections.Generic;
using Xamarin.Forms;
using System;

namespace Imi.Project.Mobile.ViewModels
{
    public class StudentMatchViewModel : FreshBasePageModel
    {
        public StudentMatchViewModel(IApiMatchService matchService, IApiRecruiterService recruiterService, IApiCompanyService companyService)
        {
            _matchService = matchService;
            _recruiterService = recruiterService;
            _companyService = companyService;
        }
        #region OverrideMethods
        public async override void Init(object initData)
        {
            base.Init(initData);
            var recruiters = await _matchService.GetAllByStudent(LoginState.Id);
            List<Recruiter> recruiterList = new List<Recruiter>();
            foreach (MatchResponseDto matchdto in recruiters)
            {
                var recruiterDto = _recruiterService.GetById(matchdto.RecruiterId).Result;
                var recruiter = new Recruiter()
                {
                    Id = recruiterDto.Id,
                    FirstName = recruiterDto.FirstName,
                    ImageUrl = recruiterDto.ImageUrl,
                    Company = (await _companyService.GetCompanyById(recruiterDto.CompanyId)).MapToEntity()
                };
                recruiterList.Add(recruiter);
            }
            Recruiters = new ObservableCollection<Recruiter>(recruiterList);
            RaisePropertyChanged("Recruiters");
        }
        #endregion
        #region Properties
        private readonly IApiMatchService _matchService;
        private readonly IApiRecruiterService _recruiterService;
        private readonly IApiCompanyService _companyService;
        public ObservableCollection<Recruiter> Recruiters { get; set; }
        #endregion
        #region Commands
        public ICommand OpenSettings => new Command(
            async () => await CoreMethods.PushPageModel<StudentSettingsViewModel>(null, false, true)
            );
        public ICommand GoHome => new Command(
            async () => await CoreMethods.PushPageModel<StudentHomeViewModel>(null, false, true)
            );
        public ICommand Detail => new Command<object>(
            async (object args) => await CoreMethods.PushPageModel<StudentDetailViewModel>(((Student)((Frame)args).BindingContext).Id, false, true)
            );
        #endregion
        #region Methods
        #endregion
    }
}
