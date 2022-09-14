using Imi.Project.Blazor.Core.Modals;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Imi.Project.Blazor.Components.Base
{
    public class RecruiterLikeComponentBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<Student> Students { get; set; }
        [Parameter]
        public EventCallback OnLikeClick { get; set; }
        [Parameter]
        public EventCallback<string> OnDetailClick { get; set; }
        [Parameter]
        public EventCallback OnDislikeClick { get; set; }
    }
}
