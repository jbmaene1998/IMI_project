using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.DataSeeders
{
    public class SchoolSeeder
    {
        static List<School> schools;
        public SchoolSeeder(DataSeederService csvService)
        {
        }
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>()
                .HasMany(l => l.Students)
                .WithOne(r => r.School)
                .OnDelete(DeleteBehavior.NoAction);

            DataSeederService _dataSeederService = new DataSeederService();

            schools = _dataSeederService.CreateSchools();

            modelBuilder.Entity<School>().HasData(schools);
        }
    }
}
