using FreshMvvm;
using Imi.Project.Mobile.Core.Domain.Interfaces.Api;
using Imi.Project.Mobile.Core.Domain.Services.Api;
using Imi.Project.Mobile.Core.Domain.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using Imi.Project.Mobile.Core.Modals;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class StudentDetailViewModel : FreshBasePageModel
    {
        public StudentDetailViewModel(string studentId, IApiStudentService studentService)
        {
            _studentService = studentService;
            Student = new Student();
            Student.Id = studentId;
            LoadDetails();
        }
        #region OverrideMethods
        public override void Init(object initData)
        {
            base.Init(initData);
        }
        #endregion
        #region Properties
        public Student Student { get; set; }
        private readonly IApiStudentService _studentService;
        #endregion
        #region Commands
        public ICommand OpenSettings => new Command(
            async () => await CoreMethods.PushPageModel<RecruiterSettingsViewModel>(null, false, true)
            );
        public ICommand GoHome => new Command(
            async () => await CoreMethods.PushPageModel<RecruiterHomeViewModel>(null, false, true)
            );
        #endregion
        #region Methods
        private async void LoadDetails()
        {
            Student = (await _studentService.GetById(Student.Id)).MapToEntity();
            RaisePropertyChanged(nameof(Student));
        }
        #endregion
    }
}
