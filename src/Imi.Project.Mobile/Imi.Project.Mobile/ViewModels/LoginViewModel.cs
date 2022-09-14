using FreshMvvm;
using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Domain.Interfaces.Api;
using Imi.Project.Mobile.Core.Domain.Services.Api;
using Imi.Project.Mobile.Core.Domain.Services.Mocking;
using Imi.Project.Mobile.Core.Modals;
using Imi.Project.Mobile.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class LoginViewModel : FreshBasePageModel
    {
        public LoginViewModel(IApiUserService userService)
        {
            _userService = userService;
        }
        #region OverrideMethods
        #endregion
        #region Properties
        IApiUserService _userService;

        public string Email { get; set; }
        public string Password { get; set; }
        #endregion
        #region Commands
        public ICommand LoginUser => new Command(
            async () => await Login()
            );
        public ICommand CreateUser => new Command(
            async () => await CoreMethods.PushPageModel<ChooseUserTypeViewModel>(null, false, true)
            );

        #endregion
        #region Methods
        private async Task Login()
        {
            if (Email != null && Password != null)
            {
                string token = await _userService.Login(Email, Password);
                
                if (token != null)
                {
                    if (LoginState.IsRecruiter)
                    {
                        await CoreMethods.PushPageModel<RecruiterHomeViewModel>(null, false, true);
                    }
                    else await CoreMethods.PushPageModel<StudentHomeViewModel>(null, false, true);
                }
                else
                {
                    await CoreMethods.DisplayAlert("Error", "Email or password are incorrect. Please try again.", "I understand");
                }
            }
            else await CoreMethods.DisplayAlert("Error", "Please fill in all fields", "I understand");
        }
        #endregion
    }
}
