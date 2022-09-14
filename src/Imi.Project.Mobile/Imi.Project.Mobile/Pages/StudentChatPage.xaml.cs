using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentChatPage : ContentPage
    {
        private Student currentStudent;
        public StudentChatPage(Student student)
        {
            InitializeComponent();
            currentStudent = student;
        }

        private async void BtnMatch_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudentMatchPage());
        }

        private async void BtnSettings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudentSettingsPage(currentStudent));
        }
        private async void BtnSend_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Message has been send", "Close");
        }
    }
}