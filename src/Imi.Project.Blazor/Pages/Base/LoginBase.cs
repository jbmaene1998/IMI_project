using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Imi.Project.Blazor.Core;
using Imi.Project.Blazor.Core.Interfaces;
using Imi.Project.Blazor.Core.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Imi.Project.Blazor.Core.Modals;
using Imi.Project.Blazor.CoreModals.Base;

namespace Imi.Project.Blazor.Pages.Base
{
    public class LoginBase : ComponentBase
    {
        private readonly IApiUserService _userService;
        public Credentials _credentials;
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        private LoginState LoginState { get; set; }
        public LoginBase()
        {
            _userService = new ApiUserService();
            _credentials = new Credentials();
        }
        
        public BasePerson Person { get; set; }
        public async Task Validate()
        {
            if (_credentials.Email != null && _credentials.Password != null)
            {
                try
                {
                    await _userService.Login(_credentials.Email, _credentials.Password);
                    if (LoginState.Id != null)
                    {
                        NavigationManager.NavigateTo($"home", false);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public void ToCreateRecruiter()
        {
            NavigationManager.NavigateTo($"create", false);
        }
    }
}

