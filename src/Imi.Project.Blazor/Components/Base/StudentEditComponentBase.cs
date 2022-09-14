using Imi.Project.Blazor.Core.Modals;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Components.Base
{
    public class StudentEditComponentBase : ComponentBase
    {
        [Parameter]
        public Student Student { get; set; }

        [Parameter]
        public EventCallback OnSave { get; set; }        
        [Parameter]
        public EventCallback OnSchoolInput { get; set; }
        [Parameter]
        public EventCallback OnCityInput { get; set; }
        [Parameter]
        public EventCallback OnJobInput { get; set; }
        [Parameter]
        public EventCallback OnSelectJob { get; set; }
        [Parameter]
        public EventCallback OnSelectCity { get; set; }
        [Parameter]
        public EventCallback OnSelectSchool { get; set; }
        [Parameter]
        public string SchoolSearchText { get; set; }
        [Parameter]
        public string CitySearchText { get; set; }
        [Parameter]
        public string JobSearchText { get; set; }
        [Parameter]
        public List<School> Schools { get; set; }
        [Parameter]
        public List<Location> Locations { get; set; }
        [Parameter]
        public List<Job> Jobs { get; set; }

    }
}