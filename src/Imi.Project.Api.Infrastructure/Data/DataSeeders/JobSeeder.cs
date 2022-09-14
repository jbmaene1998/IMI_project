using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.DataSeeders
{
    public class JobSeeder
    {
        static List<Job> jobs;
        public JobSeeder()
        {
        }
        public static void Seed(ModelBuilder modelBuilder)
        {
            DataSeederService _dataSeederService = new DataSeederService();

            jobs = _dataSeederService.CreateJobs();

            modelBuilder.Entity<Job>()
                .HasMany(j => j.Vacancies)
                .WithOne(v => v.Job)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Job>()
                .HasMany(j => j.Students)
                .WithOne(v => v.Job)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Job>().HasData(jobs);
        }
    }
}
