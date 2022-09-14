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
    internal class IdentitySeeder
    {
        public IdentitySeeder()
        {
        }
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasePerson>().Ignore(i => i.AccessFailedCount);
            modelBuilder.Entity<BasePerson>().Ignore(i => i.PhoneNumberConfirmed);
            modelBuilder.Entity<BasePerson>().Ignore(i => i.TwoFactorEnabled);
            modelBuilder.Entity<BasePerson>().Ignore(i => i.LockoutEnabled);
            modelBuilder.Entity<BasePerson>().Ignore(i => i.LockoutEnd);

            modelBuilder.Entity<BasePerson>().ToTable("AspNetUsers");

            DataSeederService _dataSeederService = new DataSeederService();

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(_dataSeederService.CreateIdentityUserRole());

            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(_dataSeederService.CreateIdentityUserClaims());

            modelBuilder.Entity<IdentityRole>().HasData(_dataSeederService.CreateRoles());
        }
    }
}
