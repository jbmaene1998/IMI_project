using FluentValidation;
using FreshMvvm;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Mobile.Core;
using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Domain.Interfaces.Api;
using Imi.Project.Mobile.Core.Domain.Mapper;
using Imi.Project.Mobile.Core.Domain.Services.Api;
using Imi.Project.Mobile.Core.Domain.Services.Mocking;
using Imi.Project.Mobile.Core.Domain.Validators;
using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class ManageVacanciesViewModel : FreshBasePageModel
    {
        public ManageVacanciesViewModel(IApiVacancyService vacancyService, IApiJobService jobService, IApiSearchService searchService)
        {
            vacancy = new VacancyRequestDto();
            _vacancyService = vacancyService;
            vacancyValidator = new VacancyValidator();
            _jobService = jobService;
            _searchService = searchService;
        }
        #region OverrideMethods
        public async override void Init(object initData)
        {
            base.Init(initData);
            Vacancies = new ObservableCollection<Vacancy>();
            dtos = new List<VacancyResponseDto>(await _vacancyService.GetAllVacancies(LoginState.Id));
            foreach (var vacancy in dtos)
            {
                Vacancies.Add(vacancy.MapToEntity());
            }
            JobsIsVisible = false;
        }
        #endregion
        #region Properties
        private VacancyRequestDto vacancy;
        private readonly IApiVacancyService _vacancyService;
        private readonly IValidator vacancyValidator;
        private readonly IApiJobService _jobService;
        private readonly IApiSearchService _searchService;
        public string Name { get; set; }
        public string SearchBarText { get; set; }
        public string SearchBarId { get; set; }
        public bool JobsIsVisible { get; set; }
        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<Job> Jobs {get; set; }
        List<VacancyResponseDto> dtos;
        #endregion
        #region Commands
        public ICommand OpenSettings => new Command(
            async () => await CoreMethods.PushPageModel<RecruiterSettingsViewModel>(null, false, true)
            );
        public ICommand OpenMatches => new Command(
            async () => await CoreMethods.PushPageModel<RecruiterMatchViewModel>(null, false, true)
            );
        public ICommand AddVacancy => new Command(
            () => Create()
            );
        public ICommand TapDeleteVacancy => new Command<ItemTappedEventArgs>(
            (ItemTappedEventArgs args) => Delete((args.Item as Vacancy).Id)
            );
        public ICommand SearchCommand => new Command<TextChangedEventArgs>(
            (TextChangedEventArgs args) => Search()
            );
        public ICommand TapCommand => new Command<ItemTappedEventArgs>(
            (ItemTappedEventArgs args) => SetSearchBar(args)
            );
        #endregion
        #region Methods
        private async Task<bool> Validate(VacancyRequestDto vacancy)
        {
            var validationContext = new ValidationContext<Vacancy>(vacancy.MapToEntity());
            var validationResult = vacancyValidator.Validate(validationContext);
            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(vacancy.Name))
                {
                    await CoreMethods.DisplayAlert("Alert", error.ErrorMessage, "Close");
                }
            }
            return validationResult.IsValid;
        }

        private void SetSearchBar(ItemTappedEventArgs args)
        {
            SearchBarText = (args.Item as Job).Name;
            SearchBarId = (args.Item as Job).Id;
            JobsIsVisible = false;
            RaisePropertyChanged(nameof(JobsIsVisible));
            RaisePropertyChanged(nameof(SearchBarText));
        }
        private async void Search()
        {
            var text = SearchBarText;
            if (text.Length != 0)
            {
                if (text[0] != " "[0])
                {
                    if (text != null)
                    {
                        Jobs = new ObservableCollection<Job>();
                        foreach (var job in await _searchService.SearchJob(SearchBarText))
                        {
                            Jobs.Add(job.MapToEntity());
                        }
                        JobsIsVisible = true;
                        RaisePropertyChanged(nameof(JobsIsVisible));
                        RaisePropertyChanged(nameof(Jobs));
                    }
                }
            }
        }
        private async void Create()
        {
            DeleteState();
            SaveState();
            if (await Validate(vacancy))
            {
                if (await _vacancyService.HasRecruiterThis(SearchBarText))
                {
                    await _vacancyService.Add(vacancy);
                    Vacancies = null;
                    Vacancies = new ObservableCollection<Vacancy>();
                    foreach (var vacancy in await _vacancyService.GetAllVacancies(LoginState.Id))
                    {
                        Vacancies.Add(vacancy.MapToEntity());
                    }
                    RaisePropertyChanged(nameof(Vacancies));
                }
                else
                {
                    await CoreMethods.DisplayAlert("Error", "This already exists", "Close");
                }
            }
        }
        private void DeleteState()
        {
            vacancy.Name = "";
        }
        private async void Delete(string args)
        {
            await _vacancyService.Delete(args);
            Vacancies = null;
            Vacancies = new ObservableCollection<Vacancy>();
            foreach (var vacancy in await _vacancyService.GetAllVacancies(LoginState.Id))
            {
                Vacancies.Add(vacancy.MapToEntity());
            }
            RaisePropertyChanged(nameof(Vacancies));
        }
        private async void SaveState()
        {
            vacancy.Id = Guid.NewGuid().ToString();
            vacancy.JobId = SearchBarId;
            vacancy.Name = SearchBarText;
            vacancy.RecruiterId = LoginState.Id;
        }
        #endregion
    }
}

