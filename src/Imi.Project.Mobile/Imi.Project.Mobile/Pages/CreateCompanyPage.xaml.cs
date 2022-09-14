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
    public partial class CreateCompanyPage : ContentPage
    {
        private IValidator buildingValidator;
        private readonly ICompanyService _companyService;
        private Company currentCompany;
        public CreateCompanyPage()
        {
            InitializeComponent();
            buildingValidator = new BuildingValidator();
            _companyService = new MockCompanyService();
            currentCompany = new Company();
            DeleteErrors();
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
            int postcode;
            if (TxtPostcode.Text != null) postcode = Convert.ToInt32(TxtPostcode.Text);
            else postcode = 0;
            currentCompany.Id = Guid.NewGuid().ToString();
            currentCompany.Name = TxtName.Text;
            currentCompany.PostCode = postcode;
            currentCompany.Street = TxtStreet.Text;
            currentCompany.WebsiteUrl = TxtWebsite.Text;
        }

        private void DeleteState()
        {
            currentCompany.Name = "";
            currentCompany.PostCode = 0;
            currentCompany.Street = "";
            currentCompany.WebsiteUrl = "";
        }
        private async void CreateCompany_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }

        private async void BtnCreateCompany_Clicked(object sender, EventArgs e)
        {
            DeleteState();
            SaveState();
            if (Validate(currentCompany))
            {
                await _companyService.Add(currentCompany);
                await Navigation.PopModalAsync(true);
            }
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
    }
}