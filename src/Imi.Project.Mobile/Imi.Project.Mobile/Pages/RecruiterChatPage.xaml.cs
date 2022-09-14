using FluentValidation;
using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Domain.Services.Mocking;
using Imi.Project.Mobile.Core.Domain.Validators;
using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecruiterChatPage : ContentPage
    {
        private Recruiter currentRecruiter;
        public RecruiterChatPage(Recruiter recruiter)
        {
            InitializeComponent();
            currentRecruiter = recruiter;
        }

        private async void Match_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecruiterMatchPage());
        }

        private async void Settings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecruiterSettingsPage());
        }

        private async void Send_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Message has been send", "Close");
        }
    }
}