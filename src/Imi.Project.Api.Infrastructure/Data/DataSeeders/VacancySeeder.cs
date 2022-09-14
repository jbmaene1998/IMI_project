using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Imi.Project.Api.Infrastructure.Data.DataSeeders
{
    public class VacancySeeder
    {
        static List<Vacancy> vacancies;
        public VacancySeeder()
        {
        }
        public static void Seed(ModelBuilder modelBuilder)
        {
            DataSeederService _dataSeederService = new DataSeederService();

            vacancies = _dataSeederService.CreateVacancies();

            modelBuilder.Entity<Vacancy>()
                .HasOne(m => m.Recruiter)
                .WithMany(s => s.Vacancies)
                .HasForeignKey(m => m.RecruiterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Vacancy>().HasData(vacancies);
        }
    }
}
