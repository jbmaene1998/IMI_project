using System;
using System.Collections.Generic;
using System.Text;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Imi.Project.Api.Infrastructure.Data.DataSeeders
{
    public class LocationSeeder
    {
        public LocationSeeder()
        {
        }
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasMany(l => l.Recruiters)
                .WithOne(r => r.Location)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Location>()
                .HasMany(l => l.Students)
                .WithOne(r => r.Location)
                .OnDelete(DeleteBehavior.NoAction);

            var _dataSeederService = new DataSeederService();

            modelBuilder.Entity<Location>().HasData(_dataSeederService.CreateLocations());
        }
    }
}
