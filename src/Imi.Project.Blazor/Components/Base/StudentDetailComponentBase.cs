using Imi.Project.Blazor.Core.Modals;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Components.Base
{
    public class StudentDetailComponentBase : ComponentBase
    {
        [Parameter]
        public Student Student{ get; set; }
        [Parameter]
        public EventCallback OnGoBackClick { get; set; }
    }
}
