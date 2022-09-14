using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Core.Domain.Mapper;
using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Domain.Interfaces.Api;
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
using Imi.Project.Mobile.Core;
using Imi.Project.Api.Core.Dtos;
using System.Linq;

namespace Imi.Project.Mobile.ViewModels
{
    public class CreateRecruiterViewModel : FreshBasePageModel
    {
        public CreateRecruiterViewModel(Recruiter user,
            IApiRecruiterService recruiterService,
            IApiSearchService searchService,
            IApiLocationService locationService,
            IApiCompanyService companyService)
        {
            if (LoginState.Id is null) isNewRecruiter = true;
            recruiterValidator = new RecruiterValidator();
            _recruiterService = recruiterService;
            _searchService = searchService;
            _locationService = locationService;
            _companyService = companyService;
            if (LoginState.Id != null)
            {
                currentRecruiter = (_recruiterService.GetById(LoginState.Id).Result).MapToEntity();
                SearchBarCompany = currentRecruiter.Company.Name;
                EntryContinent = currentRecruiter.Location.Continent;
                EntryCountry = currentRecruiter.Location.Country;
                SearchBarLocation = currentRecruiter.Location.City;
                FirstName = currentRecruiter.FirstName;
                LastName = currentRecruiter.LastName;
                DateOfBirth = currentRecruiter.DateOfBirth;
                Email = currentRecruiter.Email;
                Phone = currentRecruiter.Phone;
                User = currentRecruiter;
            }
            LocationsIsVisible = false;
            CompanyIsVisible = false;
            ContinentIsVisible = false;
            CountryIsVisible = false;
            RaisePropertyChanged(nameof(User.FirstName));
        }
        #region OverrideMethods
        public async override void Init(object initData)
        {
            base.Init(initData);

            if (initData != null) User = initData as Recruiter;
        }

        #endregion
        #region Properties
        private readonly IValidator recruiterValidator;
        private readonly IApiRecruiterService _recruiterService;
        private readonly IApiSearchService _searchService;
        private readonly IApiLocationService _locationService;
        private readonly IApiCompanyService _companyService;
        private DateTime tempDate;
        private Recruiter currentRecruiter;
        private readonly bool isNewRecruiter;
        public Recruiter User { get; set; }
        public bool LocationsIsVisible { get; set; }
        public bool CompanyIsVisible { get; set; }
        public bool ContinentIsVisible { get; set; }
        public bool CountryIsVisible { get; set; }
        public string SearchBarLocation { get; set; }
        public string SearchBarCompany { get; set; }
        public string EntryContinent { get; set; }
        public string EntryCountry { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }
        public RegisterRecruiterRequestDto RegisterDto { get; set; }
        public Location Location { get; set; }
        public Company Company { get; set; }
        public ObservableCollection<Location> Locations { get; set; }
        public ObservableCollection<Location> Continents { get; set; }
        public ObservableCollection<Location> Countries { get; set; }
        public ObservableCollection<Company> Companies { get; set; }
        #endregion
        #region Commands
        public ICommand AddCompany => new Command(
            async () => throw new NotImplementedException()
            );
        public ICommand AddRecruiter => new Command(
            () => CreateRecruiter()
            );
        public ICommand TapCompany => new Command<ItemTappedEventArgs>(
            (ItemTappedEventArgs args) => SetSearchBarCompany(args)
            );
        public ICommand TapLocation => new Command<ItemTappedEventArgs>(
            (ItemTappedEventArgs args) => SetSearchBarLocation(args)
            );
        public ICommand TapContinent => new Command<ItemTappedEventArgs>(
            (ItemTappedEventArgs args) => SetEntryContinent(args)
            );
        public ICommand TapCountry => new Command<ItemTappedEventArgs>(
            (ItemTappedEventArgs args) => SetEntryCountry(args)
            );
        public ICommand SearchCompanyCommand => new Command<TextChangedEventArgs>(
            (TextChangedEventArgs args) => SearchCompany()
            );
        public ICommand SearchCountryCommand => new Command<TextChangedEventArgs>(
            (TextChangedEventArgs args) => SearchCountry()
            );
        public ICommand SearchContinentCommand => new Command<TextChangedEventArgs>(
            (TextChangedEventArgs args) => SearchContinent()
            );
        public ICommand SearchLocationCommand => new Command<TextChangedEventArgs>(
            (TextChangedEventArgs args) => SearchLocation()
            );
        #endregion
        #region Methods
        private void SetSearchBarCompany(ItemTappedEventArgs args)
        {
            SearchBarCompany = (args.Item as Company).Name;
            Company = args.Item as Company;
            CompanyIsVisible = false;
            RaisePropertyChanged(nameof(SearchBarCompany));
            RaisePropertyChanged(nameof(CompanyIsVisible));

        }
        private void SetSearchBarLocation(ItemTappedEventArgs args)
        {
            SearchBarLocation = (args.Item as Location).City;
            Location = args.Item as Location;
            LocationsIsVisible = false;
            RaisePropertyChanged(nameof(User.Location));
            RaisePropertyChanged(nameof(SearchBarLocation));
            RaisePropertyChanged(nameof(LocationsIsVisible));
        }
        private void SetEntryContinent(ItemTappedEventArgs args)
        {
            EntryContinent = (args.Item as Location).Output;
            ContinentIsVisible = false;
            RaisePropertyChanged(nameof(User.Location));
            RaisePropertyChanged(nameof(EntryContinent));
            RaisePropertyChanged(nameof(ContinentIsVisible));

        }
        private void SetEntryCountry(ItemTappedEventArgs args)
        {
            EntryCountry = (args.Item as Location).Output;
            CountryIsVisible = false;
            RaisePropertyChanged(nameof(CountryIsVisible));
            RaisePropertyChanged(nameof(EntryCountry));
        }

        private async void SearchCompany()
        {
            var text = SearchBarCompany;
            if (text.Length != 0)
            {
                if (text[0] != " "[0])
                {
                    if (text != null)
                    {
                        Companies = new ObservableCollection<Company>();
                        foreach (var company in await _searchService.SearchCompany(text))
                        {
                            Companies.Add(company.MapToEntity());
                        }
                        CompanyIsVisible = true;
                        RaisePropertyChanged(nameof(CompanyIsVisible));
                        RaisePropertyChanged(nameof(Companies));
                    }
                }
            }
        }
        private async void SearchLocation()
        {
            var text = SearchBarLocation;
            if (text.Length != 0)
            {
                if (text[0] != " "[0])
                {
                    if (text != null)
                    {
                        Locations = new ObservableCollection<Location>();
                        var locations = await _searchService.SearchLocation(EntryContinent, EntryCountry, text);
                        foreach (var location in locations)
                        {
                            Locations.Add(location.MapToEntity());
                        }
                        LocationsIsVisible = true;
                        RaisePropertyChanged(nameof(LocationsIsVisible));
                        RaisePropertyChanged(nameof(Locations));
                    }
                }
            }
        }
        private async void SearchContinent()
        {
            var text = EntryContinent;
            if (text.Length != 0)
            {
                if (text[0] != " "[0])
                {
                    if (text != null)
                    {
                        Continents = new ObservableCollection<Location>();
                        var continents = await _locationService.GetContinents();
                        continents = continents.Where(x => x.Output.Contains(text));
                        foreach (var continent in continents)
                        {
                            Continents.Add(continent.MapToEntity());
                        }
                        ContinentIsVisible = true;
                        RaisePropertyChanged(nameof(ContinentIsVisible));
                        RaisePropertyChanged(nameof(Continents));
                    }
                }
            }
        }
        private async void SearchCountry()
        {
            var text = EntryCountry;
            if (text.Length != 0)
            {
                if (text[0] != " "[0])
                {
                    if (text != null)
                    {
                        Countries = new ObservableCollection<Location>();
                        var countries = await _locationService.GetCountriesByContinent(EntryContinent);
                        countries = countries.Where(x => x.Output.Contains(EntryCountry));
                        foreach (var country in countries)
                        {
                            Countries.Add(country.MapToEntity());
                        }
                        CountryIsVisible = true;
                        RaisePropertyChanged(nameof(CountryIsVisible));
                        RaisePropertyChanged(nameof(Countries));
                    }
                }
            }
        }
        private bool Validate(Recruiter recruiter)
        {
            var validationContext = new ValidationContext<Recruiter>(recruiter);
            var validationResult = recruiterValidator.Validate(validationContext);

            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(recruiter.FirstName))
                {
                    CoreMethods.DisplayAlert("Error", error.ErrorMessage, "I understand");
                }
                if (error.PropertyName == nameof(recruiter.LastName))
                {
                    CoreMethods.DisplayAlert("Error", error.ErrorMessage, "I understand");
                }
                if (error.PropertyName == nameof(recruiter.Email))
                {
                    CoreMethods.DisplayAlert("Error", error.ErrorMessage, "I understand");
                }
                if (error.PropertyName == nameof(recruiter.Phone))
                {
                    CoreMethods.DisplayAlert("Error", error.ErrorMessage, "I understand");
                }
                if (error.PropertyName == nameof(recruiter.Password))
                {
                    CoreMethods.DisplayAlert("Error", error.ErrorMessage, "I understand");
                }
                if (error.PropertyName == nameof(recruiter.DateOfBirth))
                {
                    CoreMethods.DisplayAlert("Error", error.ErrorMessage, "I understand");
                }
                if (error.PropertyName == nameof(recruiter.ImageUrl))
                {
                    CoreMethods.DisplayAlert("Error", error.ErrorMessage, "I understand");
                }
            }
            return validationResult.IsValid;
        }
        private async void CreateRecruiter()
        {
            SaveState();
            if (Validate(currentRecruiter))
            {
                if (SearchBarLocation != null || SearchBarLocation != "")
                {
                    if (isNewRecruiter)
                    {
                        await _recruiterService.Add(RegisterDto);
                        await CoreMethods.PushPageModel<LoginViewModel>(null, false, true);
                    }
                    else
                    {
                        var request = new RecruiterRequestDto
                        {
                            Id = currentRecruiter.Id,
                            LastName = currentRecruiter.LastName,
                            FirstName = currentRecruiter.FirstName,
                            DateOfBirth = currentRecruiter.DateOfBirth,
                            PhoneNumber = currentRecruiter.Phone,
                            Email = currentRecruiter.Email,
                            Password = currentRecruiter.Password,
                            ImageUrl = currentRecruiter.ImageUrl,
                            CompanyId = currentRecruiter.CompanyId,
                            LocationId = currentRecruiter.LocationId,
                        };

                        await _recruiterService.Update(request);
                        await CoreMethods.PushPageModel<RecruiterHomeViewModel>(null, false, true);
                    }
                }
                else
                {
                    await CoreMethods.DisplayAlert("Error", "Please select a location", "I understand");
                }
            }
        }

        private void DeleteState()
        {
            currentRecruiter.Email = "";
            currentRecruiter.Phone = "";
            currentRecruiter.FirstName = "";
            currentRecruiter.LastName = "";
            currentRecruiter.Password = "";
        }

        private void SaveState()
        {
            if (isNewRecruiter)
            {
                RegisterDto = new RegisterRecruiterRequestDto();
                RegisterDto.Id = Guid.NewGuid().ToString();
                RegisterDto.DateOfBirth = DateOfBirth;
                RegisterDto.Email = Email;
                RegisterDto.PhoneNumber = Phone;
                RegisterDto.FirstName = FirstName;
                RegisterDto.LastName = LastName;
                RegisterDto.Password = Password;
                RegisterDto.CompanyId = Company.Id;
                RegisterDto.LocationId = Location.Id;
                RegisterDto.ImageUrl = "https://thispersondoesnotexist.com/image";
                RegisterDto.ConfirmPassword = Password;
                //for validation
                currentRecruiter = new Recruiter();
                currentRecruiter.DateOfBirth = DateOfBirth;
                currentRecruiter.Email = Email;
                currentRecruiter.Phone = Phone;
                currentRecruiter.FirstName = FirstName;
                currentRecruiter.LastName = LastName;
                currentRecruiter.Password = Password;
                currentRecruiter.ImageUrl = "https://thispersondoesnotexist.com/image";
            }
            else
            {
                currentRecruiter.DateOfBirth = DateOfBirth;
                currentRecruiter.Email = Email;
                currentRecruiter.Phone = Phone;
                currentRecruiter.FirstName = FirstName;
                currentRecruiter.LastName = LastName;
                currentRecruiter.Password = Password;
                currentRecruiter.Company = Company;
                currentRecruiter.Location = Location;
                currentRecruiter.ImageUrl = "https://thispersondoesnotexist.com/image";
            }
        }
        #endregion
    }
}
