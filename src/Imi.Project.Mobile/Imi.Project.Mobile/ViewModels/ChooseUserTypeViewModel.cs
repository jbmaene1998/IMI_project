using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class ChooseUserTypeViewModel : FreshBasePageModel
    {
        public ICommand CreateRecruiter => new Command(
        async () => await CoreMethods.PushPageModel<CreateRecruiterViewModel>(null, false, true)
        );
        public ICommand CreateStudent => new Command(
        async () => await CoreMethods.PushPageModel<CreateStudentViewModel>(null, false, true)
        );
    }
}
