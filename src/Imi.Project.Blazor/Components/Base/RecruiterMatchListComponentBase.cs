using Imi.Project.Api.Core.Dtos;
using Imi.Project.Blazor.Core.Modals;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Components.Base
{
    public class RecruiterMatchListComponentBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<Match> Matches { get; set; }
        [Parameter]
        public EventCallback<string> OnDetailClick { get; set; }
    }
}
