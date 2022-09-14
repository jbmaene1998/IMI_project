using FluentValidation;
using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Domain.Services.Mocking;
using Imi.Project.Mobile.Core.Domain.Validators;
using Imi.Project.Mobile.Core.Modals;
using Imi.Project.Mobile.Core.Modals.BaseEntities;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateSchoolPage : ContentPage
    {
        private IValidator buildingValidator;
        private readonly ISchoolService _schoolService;
        private School currentSchool;
        public CreateSchoolPage()
        {
            InitializeComponent();
            buildingValidator = new BuildingValidator();
            _schoolService = new MockSchoolService();
            currentSchool = new School();
            DeleteErrors();
        }


        private bool Validate(BaseBuilding building)
        {
            var validationContext = new ValidationContext<BaseBuilding>(building);
            var validationResult = buildingValidator.Validate(validationContext);
            DeleteErrors();
            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(building.Name))
                {
                    LblName.Text = error.ErrorMessage;
                    LblName.IsVisible = true;
                }
                if (error.PropertyName == nameof(building.WebsiteUrl))
                {
                    LblUrl.Text = error.ErrorMessage;
                    LblUrl.IsVisible = true;
                }
                if (error.PropertyName == nameof(building.PostCode))
                {
                    LblPostcode.Text = error.ErrorMessage;
                    LblPostcode.IsVisible = true;
                }
                if (error.PropertyName == nameof(building.Street))
                {
                    LblStreet.Text = error.ErrorMessage;
                    LblStreet.IsVisible = true;
                }
            }
            return validationResult.IsValid;
        }
            private void DeleteErrors()
        {
            LblLocation.Text = "";
            LblLocation.IsVisible = false;
            LblName.Text = "";
            LblName.IsVisible = false;
            LblUrl.Text = "";
            LblUrl.IsVisible = false;
            LblPostcode.Text = "";
            LblPostcode.IsVisible = false;
            LblStreet.Text = "";
            LblStreet.IsVisible = false;
        }

        private void SaveState()
        {
            currentSchool.Id = Guid.NewGuid().ToString();
            currentSchool.Name = TxtName.Text;
            currentSchool.PostCode = Convert.ToInt32(TxtPostcode.Text);
            currentSchool.Street = TxtStreet.Text;
            currentSchool.WebsiteUrl = TxtWebsite.Text;
        }

        private void DeleteState()
        {
            currentSchool.Name = "";
            currentSchool.PostCode = 0;
            currentSchool.Street = "";
            currentSchool.WebsiteUrl = "";
        }

        private async void BtnCreateSchool_Clicked(object sender, EventArgs e)
        {
            DeleteState();
            SaveState();
            if (Validate(currentSchool))
            {
                await _schoolService.Add(currentSchool);
                await Navigation.PopModalAsync(true);
            }
        }
    }
}