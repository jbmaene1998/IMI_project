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
    public partial class StudentDetailPage : ContentPage
    {
        public StudentDetailPage(string id)
        {
            InitializeComponent();
        }
        //private async void BtnWebsite_OnClicked(object sender, EventArgs e)
        //{
        //    await Browser.OpenAsync(((Student)((Button)sender).BindingContext).ToString(), BrowserLaunchMode.SystemPreferred);
        //}
    }
}