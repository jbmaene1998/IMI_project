using Imi.Project.Blazor.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Components.Base
{
    public class NavigationComponentBase : ComponentBase
    {
        [Inject]
        private NavigationManager navigationManager { get; set; }
        [Inject]
        public LoginState LoginState { get; set; }
        public void OnHomeClick()
        {
            navigationManager.NavigateTo($"/home");
        }
        public void OnMatchClick()
        {
            navigationManager.NavigateTo($"/matches");
        }
        public void OnSettingsClick()
        {
            navigationManager.NavigateTo($"/edit");
        }
        public void OnVacanciesClick()
        {

        }
        public void OnLogOutClick()
        {
            LoginState.Logout();
            navigationManager.NavigateTo("/");
        }
    }
}
