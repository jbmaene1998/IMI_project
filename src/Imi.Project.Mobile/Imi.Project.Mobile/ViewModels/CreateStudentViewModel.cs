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
using System.Linq;
using Imi.Project.Api.Core.Dtos;

namespace Imi.Project.Mobile.ViewModels
{
    public class CreateStudentViewModel : FreshBasePageModel
    {
        public CreateStudentViewModel(Student user, 
            IApiStudentService studentService, 
            IApiSearchService searchService,
            IApiLocationService locationService,
            IApiJobService jobService,
            IApiSchoolService schoolService)
        {
            if (LoginState.Id is null) isNewStudent = true;
            studentValidator = new StudentValidator();
            _studentService = studentService;
            _searchService = searchService;
            _locationService = locationService;
            _schoolService = schoolService;
            if (LoginState.Id != null)
            {
                currentStudent = (_studentService.GetById(LoginState.Id).Result).MapToEntity();
                SearchBarSchool = currentStudent.School.Name;
                EntryContinent = currentStudent.Location.Continent;
                EntryCountry = currentStudent.Location.Country;
                SearchBarLocation = currentStudent.Location.City;
                FirstName = currentStudent.FirstName;
                LastName = currentStudent.LastName;
                DateOfBirth = currentStudent.DateOfBirth;
                SearchBarJob = currentStudent.Job.Name;
                Email = currentStudent.Email;
                Phone = currentStudent.Phone;
                User = currentStudent;
            }
            LocationsIsVisible = false;
            SchoolsIsVisible = false;
            ContinentIsVisible = false;
            CountryIsVisible = false;
            RaisePropertyChanged(nameof(User.FirstName));
        }
        #region OverrideMethods
        public async override void Init(object initData)
        {
            base.Init(initData);

            if (initData != null) User = initData as Student;
        }

        #endregion
        #region Properties
        private readonly IValidator studentValidator;
        private readonly IApiStudentService _studentService;
        private readonly IApiSearchService _searchService;
        private readonly IApiLocationService _locationService;
        private readonly IApiJobService _jobService;
        private readonly IApiSchoolService _schoolService;
        private DateTime tempDate;
        private Student currentStudent;
        private readonly bool isNewStudent;
        public Student User { get; set; }
        public bool LocationsIsVisible { get; set; }
        public bool SchoolsIsVisible { get; set; }
        public bool JobsIsVisible { get; set; }
        public bool ContinentIsVisible { get; set; }
        public bool CountryIsVisible { get; set; }
        public string SearchBarLocation { get; set; }
        public string SearchBarSchool{ get; set; }
        public string SearchBarJob{ get; set; }
        public string EntryContinent{ get; set; }
        public string EntryCountry{ get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }
        public Location Location { get; set; }
        public Job Job { get; set; }
        public School School { get; set; }
        public RegisterStudentRequestDto RegisterDto { get; set; }
        public ObservableCollection<Location> Locations { get; set; }
        public ObservableCollection<Location> Continents { get; set; }
        public ObservableCollection<Location> Countries { get; set; }
        public ObservableCollection<School> Schools { get; set; }
        public ObservableCollection<Job> Jobs { get; set; }
        #endregion
        #region Commands
        public ICommand AddSchool => new Command(
            async () => throw new NotImplementedException()
            );
        public ICommand AddStudent => new Command(
            () => CreateStudent()
            );
        public ICommand TapSchool => new Command<ItemTappedEventArgs>(
            (ItemTappedEventArgs args) => SetSearchBarSchool(args)
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
        public ICommand TapJob => new Command<ItemTappedEventArgs>(
            (ItemTappedEventArgs args) => SetSearchBarJob(args)
            );
        public ICommand SearchSchoolCommand => new Command<TextChangedEventArgs>(
            (TextChangedEventArgs args) => SearchSchool()
            );
        public ICommand SearchJobCommand => new Command<TextChangedEventArgs>(
            (TextChangedEventArgs args) => SearchJob()
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
        private void SetSearchBarSchool(ItemTappedEventArgs args)
        {
            SearchBarSchool = (args.Item as School).Name;
            School = args.Item as School;
            SchoolsIsVisible = false;
            RaisePropertyChanged(nameof(SearchBarSchool));
            RaisePropertyChanged(nameof(SchoolsIsVisible));
            
        }
        private void SetSearchBarJob(ItemTappedEventArgs args)
        {
            SearchBarJob = (args.Item as Job).Name;
            Job = args.Item as Job;
            JobsIsVisible = false;
            RaisePropertyChanged(nameof(User));
            RaisePropertyChanged(nameof(SearchBarJob));
            RaisePropertyChanged(nameof(JobsIsVisible));
            
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

        private async void SearchSchool()
        {
            var text = SearchBarSchool;
            if (text.Length != 0)
            {
                if (text[0] != " "[0])
                {
                    if (text != null)
                    {
                        Schools = new ObservableCollection<School>();
                        foreach (var school in await _searchService.SearchSchool(text))
                        {
                            Schools.Add(school.MapToEntity());
                        }
                        SchoolsIsVisible = true;
                        RaisePropertyChanged(nameof(SchoolsIsVisible));
                        RaisePropertyChanged(nameof(Schools));
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

        private async void SearchJob()
        {
            var text = SearchBarJob;
            if (text.Length != 0)
            {
                if (text[0] != " "[0])
                {
                    if (text != null)
                    {
                        Jobs = new ObservableCollection<Job>();
                        foreach (var job in await _searchService.SearchJob(text))
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
        private bool Validate(Student student)
        {
            var validationContext = new ValidationContext<Student>(student);
            var validationResult = studentValidator.Validate(validationContext);

            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(student.FirstName))
                {
                    CoreMethods.DisplayAlert("Error", error.ErrorMessage, "I understand");
                }
                if (error.PropertyName == nameof(student.LastName))
                {
                    CoreMethods.DisplayAlert("Error", error.ErrorMessage, "I understand");
                }
                if (error.PropertyName == nameof(student.Email))
                {
                    CoreMethods.DisplayAlert("Error", error.ErrorMessage, "I understand");
                }
                if (error.PropertyName == nameof(student.Phone))
                {
                    CoreMethods.DisplayAlert("Error", error.ErrorMessage, "I understand");
                }
                if (error.PropertyName == nameof(student.DateOfBirth))
                {
                    CoreMethods.DisplayAlert("Error", error.ErrorMessage, "I understand");
                }
                if (error.PropertyName == nameof(student.ImageUrl))
                {
                    CoreMethods.DisplayAlert("Error", error.ErrorMessage, "I understand");
                }
            }
            return validationResult.IsValid;
        }
        private async void CreateStudent()
        {
            SaveState();
            if (Validate(currentStudent))
            {
                if (SearchBarLocation != null || SearchBarLocation != "")
                {
                    if (isNewStudent)
                    {
                        await _studentService.Add(RegisterDto);
                        await CoreMethods.PushPageModel<LoginViewModel>(null, false, true);
                    }
                    else
                    {
                        var request = new StudentRequestDto
                        {
                            Id = currentStudent.Id,
                            LastName = currentStudent.LastName,
                            FirstName = currentStudent.FirstName,
                            DateOfBirth = currentStudent.DateOfBirth,
                            PhoneNumber = currentStudent.Phone,
                            Email = currentStudent.Email,
                            Password = currentStudent.Password,
                            ImageUrl = currentStudent.ImageUrl,
                            SchoolId = currentStudent.SchoolId,
                            LocationId = currentStudent.LocationId,
                            JobId = currentStudent.JobId
                        };

                        await _studentService.Update(request);
                        await CoreMethods.PushPageModel<StudentHomeViewModel>(null, false, true);
                    }
                }
                else
                {
                    await CoreMethods.DisplayAlert("Error", "Please select a location", "I understand");
                }
            }
        }

        private void SaveState()
        {
            if (isNewStudent)
            {
                RegisterDto = new RegisterStudentRequestDto();
                RegisterDto.Id = Guid.NewGuid().ToString();
                RegisterDto.DateOfBirth = DateOfBirth;
                RegisterDto.Email = Email;
                RegisterDto.PhoneNumber = Phone;
                RegisterDto.FirstName = FirstName;
                RegisterDto.LastName = LastName;
                RegisterDto.Password = Password;
                RegisterDto.SchoolId = School.Id;
                RegisterDto.LocationId = Location.Id;
                RegisterDto.JobId = Job.Id;
                RegisterDto.ImageUrl = "https://thispersondoesnotexist.com/image";
                RegisterDto.ConfirmPassword = Password;
                //for validation
                currentStudent = new Student();
                currentStudent.DateOfBirth = DateOfBirth;
                currentStudent.Email = Email;
                currentStudent.Phone = Phone;
                currentStudent.FirstName = FirstName;
                currentStudent.LastName = LastName;
                currentStudent.Password = Password;
                currentStudent.ImageUrl = "https://thispersondoesnotexist.com/image";
            }
            else
            {
                currentStudent.DateOfBirth = DateOfBirth;
                currentStudent.Email = Email;
                currentStudent.Phone = Phone;
                currentStudent.FirstName = FirstName;
                currentStudent.LastName = LastName;
                currentStudent.Password = Password;
                currentStudent.School = School;
                currentStudent.Job = Job;
                currentStudent.Location = User.Location;
                currentStudent.ImageUrl = "https://thispersondoesnotexist.com/image";
            }
        }
        #endregion
    }
}
