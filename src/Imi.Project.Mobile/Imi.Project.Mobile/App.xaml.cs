using FreshMvvm;
using Imi.Project.Mobile.Core.Domain.Interfaces.Api;
using Imi.Project.Mobile.Core.Domain.Services.Api;
using Imi.Project.Mobile.ViewModels;
using System;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) =>
                true;


            FreshIOC.Container.Register<IApiCompanyService>(new ApiCompanyService());
            FreshIOC.Container.Register<IApiJobService>(new ApiJobService());
            FreshIOC.Container.Register<IApiMatchService>(new ApiMatchService());
            FreshIOC.Container.Register<IApiRecruiterService>(new ApiRecruiterService());
            FreshIOC.Container.Register<IApiSchoolService>(new ApiSchoolService());
            FreshIOC.Container.Register<IApiLocationService>(new ApiLocationService());
            FreshIOC.Container.Register<IApiStudentService>(new ApiStudentService());
            FreshIOC.Container.Register<IApiUserService>(new ApiUserService());
            FreshIOC.Container.Register<IApiSearchService>(new ApiSearchService());
            FreshIOC.Container.Register<IApiVacancyService>(new ApiVacancyService());
            FreshIOC.Container.Register<IApiLikeService>(new ApiLikeService());

            var page = FreshPageModelResolver.ResolvePageModel<LoginViewModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
