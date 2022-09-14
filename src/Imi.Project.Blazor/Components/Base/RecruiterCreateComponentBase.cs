using Imi.Project.Blazor.Core.Modals;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Imi.Project.Blazor.Components.Base
{
    public class RecruiterCreateComponentBase : ComponentBase
    {
        [Parameter]
        public string CompanyId { get; set; }
        [Parameter]
        public Company Company { get; set; }
        [Parameter]
        public string LastName { get; set; }
        [Parameter]
        public string FirstName { get; set; }
        [Parameter]
        public string ImageUrl { get; set; }
        [Parameter]
        public string LocationId { get; set; }
        [Parameter]
        public Location Location { get; set; }
        [Parameter]
        public string Phone { get; set; }
        [Parameter]
        public string Email { get; set; }
        [Parameter]
        public string Password { get; set; }
        [Parameter]
        public Recruiter Recruiter { get; set; }
        [Parameter]
        public EventCallback OnSave { get; set; }
        [Parameter]
        public EventCallback OnCompanyInput { get; set; }
        [Parameter]
        public EventCallback OnCityInput { get; set; }
        [Parameter]
        public EventCallback OnSelectCity { get; set; }
        [Parameter]
        public EventCallback OnSelectCompany { get; set; }
        [Parameter]
        public string CompanySearchText { get; set; }
        [Parameter]
        public string CitySearchText { get; set; }
        [Parameter]
        public List<Company> Companies { get; set; }
        [Parameter]
        public List<Location> Locations { get; set; }
    }
}
