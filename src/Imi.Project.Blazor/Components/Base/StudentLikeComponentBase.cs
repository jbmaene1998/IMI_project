using Imi.Project.Blazor.Core.Modals;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Imi.Project.Blazor.Components.Base
{
    public class StudentLikeComponentBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<Recruiter> Recruiters { get; set; }
        [Parameter]
        public EventCallback OnLikeClick { get; set; }
        [Parameter]
        public EventCallback<string> OnDetailClick { get; set; }
        [Parameter]
        public EventCallback OnDislikeClick { get; set; }

    }
}
