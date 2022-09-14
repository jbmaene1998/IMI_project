using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Domain.Services.Mocking;
using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using Imi.Project.Mobile.Core.Modals;
using Imi.Project.Mobile.ViewModels;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecruiterDetailPage : ContentPage
    {
        public RecruiterDetailPage(string id)
        {
            InitializeComponent();
        }

    }
}