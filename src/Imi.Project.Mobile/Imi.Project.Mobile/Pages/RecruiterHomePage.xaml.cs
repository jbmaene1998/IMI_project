using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Domain.Services.Mocking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using MLToolkit.Forms.SwipeCardView.Core;
using Imi.Project.Mobile.ViewModels;
using Imi.Project.Mobile.Core.Modals;
using Imi.Project.Mobile.Core.Domain.Services.Api;
using Imi.Project.Mobile.Core.Domain.Interfaces.Api;
using Imi.Project.Mobile.Core;
using Imi.Project.Api.Core.Dtos;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecruiterHomePage : ContentPage
    {
        public RecruiterHomePage()
        {
            InitializeComponent();
        }
    }
}