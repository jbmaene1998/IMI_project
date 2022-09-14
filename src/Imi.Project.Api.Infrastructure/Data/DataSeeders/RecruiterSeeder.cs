using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.BaseEntities;
using Imi.Project.Api.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.DataSeeders
{
    public class RecruiterSeeder
    {
        static List<Recruiter> recruiters;
        public RecruiterSeeder()
        {
        }
        public static void Seed(ModelBuilder modelBuilder)
        {

            DataSeederService _dataSeederService = new DataSeederService();

            recruiters = _dataSeederService.CreateRecruiters();

            modelBuilder.Entity<Recruiter>().HasData(recruiters);
        }
    }
}
