using Imi.Project.Blazor.Core.Modals;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Imi.Project.Blazor.Components.Base
{
    public class RecruiterEditComponentBase : ComponentBase 
    {
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
