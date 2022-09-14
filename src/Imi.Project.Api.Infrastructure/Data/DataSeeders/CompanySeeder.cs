using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.DataSeeders
{
    public class CompanySeeder
    {
        static List<Company> companies;
        public CompanySeeder()
        {
        }
        public static void Seed(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Company>()
                .HasMany(l => l.Recruiters)
                .WithOne(r => r.Company)
                .OnDelete(DeleteBehavior.NoAction);

            DataSeederService _dataSeederService = new DataSeederService();

            companies = _dataSeederService.CreateCompanies();

            modelBuilder.Entity<Company>().HasData(companies);
        }
    }
}
