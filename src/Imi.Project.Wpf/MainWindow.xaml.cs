using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Wpf.Core;
using Imi.Project.Wpf.Core.Interfaces;
using Imi.Project.Wpf.Core.Services.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Imi.Project.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }
        public async void Start()
        {
            await Login();
            await ListAllJobs();
        }
        public async Task Login()
        {
            ApiUserService apiUserService = new();
            var test = await apiUserService.Login("it.internships@admin.ru", "Ikbenadmin_2020");
        }
        public async Task ListAllJobs()
        {
            lstJobs.ItemsSource = null;
            ApiJobsService apiJobsService = new();
            List<Job> jobs = new List<Job>();
            var jobResponseDtos = await apiJobsService.GetAllJobs();
            foreach (var dto in jobResponseDtos)
            {
                jobs.Add(new Job { Id = dto.Id, Name = dto.Name });
            }
            lstJobs.ItemsSource = jobs;
        }

        private void lstJobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedJob = lstJobs.SelectedItem;
            if (selectedJob != null) txtName.Text = selectedJob.ToString();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ApiJobsService apiJobsService = new();
            var selectedJob = lstJobs.SelectedItem as Job;
            await apiJobsService.DeleteJob(Guid.Parse(selectedJob.Id));
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ApiJobsService apiJobsService = new();
            List<Job> jobs = new List<Job>();
            var jobResponseDtos = await apiJobsService.GetAllJobs();
            JobResponseDto selectedJob = jobResponseDtos.FirstOrDefault(x => x.Name == txtName.Text);
            bool doesExist = jobResponseDtos.Where(x => x.Name == txtName.Text).Any();
            if (doesExist)
            {
                MessageBox.Show("Job already exist");
            }
            ListAllJobs();
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ApiJobsService apiJobsService = new();
            List<Job> jobs = new List<Job>();
            var jobResponseDtos = await apiJobsService.GetAllJobs();
            bool doesExist = jobResponseDtos.Where(x => x.Name == txtName.Text).Any();
            if (doesExist) 
            { 
                MessageBox.Show("Job already exist"); 
            }
            else
            {
                JobRequestDto jobRequestDto = new JobRequestDto()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = txtName.Text
                };
                var response = await apiJobsService.AddJob(jobRequestDto);
            }
            ListAllJobs();
        }
    }
}
