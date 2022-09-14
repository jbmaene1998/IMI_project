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
    public partial class CreateStudentPage : ContentPage
    {
        public CreateStudentPage()
        {
            InitializeComponent();
        }

        public CreateStudentPage(Student student)
        {
            InitializeComponent();
        }
    }
}