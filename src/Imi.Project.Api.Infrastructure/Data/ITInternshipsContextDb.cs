using System;
using System.Collections.Generic;
using System.Linq;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.BaseEntities;
using Imi.Project.Api.Core.Interfaces.Data;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Infrastructure.Data.DataSeeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Imi.Project.Api.Infrastructure
{
    public class ITInternshipsContextDb : IdentityDbContext<BasePerson>

    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Like> Likes { get; set; }

        public ITInternshipsContextDb(DbContextOptions<ITInternshipsContextDb> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Student)
                .WithMany(s => s.Messages)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Recruiter)
                .WithMany(s => s.Messages)
                .OnDelete(DeleteBehavior.NoAction);

            LocationSeeder.Seed(modelBuilder);
            AdminSeeder.Seed(modelBuilder);
            SchoolSeeder.Seed(modelBuilder);
            CompanySeeder.Seed(modelBuilder);
            JobSeeder.Seed(modelBuilder);
            StudentSeeder.Seed(modelBuilder);
            RecruiterSeeder.Seed(modelBuilder);
            VacancySeeder.Seed(modelBuilder);
            MatchSeeder.Seed(modelBuilder);
            IdentitySeeder.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
