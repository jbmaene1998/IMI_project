using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Domain.Services.Mocking
{
    public class MockJobService : IJobService
    {
        private static List<Job> jobs = new List<Job>
        {
            new Job
            {
                Id = "00000000-0000-0000-0000-000000010000",
                Name = ".Net Engineer",
            },
            new Job
            {
                Id = "00000000-0000-0000-0000-000000020000",
                Name = "Java Engineer",
            },
            new Job
            {
                Id = "00000000-0000-0000-0000-000000030000",
                Name = "Python Engineer",
            },

        };
        public async Task<Job> Add(Job job)
        {
            jobs.Add(job);
            return await Task.FromResult(job);
        }

        public async Task<Job> Delete(string id)
        {
            var jobToDelete = jobs.FirstOrDefault(e => e.Id == id);
            jobs.Remove(jobToDelete);
            return await Task.FromResult(jobToDelete);
        }

        public async Task<IQueryable<Job>> GetAll()
        {
            var jobList = jobs.AsQueryable();
            return await Task.FromResult(jobList);
        }

        public async Task<Job> GetById(string id)
        {
            var job = jobs.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(job);
        }

        public async Task<Job> Update(Job job)
        {
            var jobToUpdate = jobs.FirstOrDefault(e => e.Id == job.Id);
            jobs.Remove(jobToUpdate);
            jobs.Add(job);
            return await Task.FromResult(job);
        }
    }
}
