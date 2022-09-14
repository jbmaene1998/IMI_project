using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.DataSeeders
{
    public class MatchSeeder
    {
        static List<Match> matches;
        public MatchSeeder()
        {
        }
        public static void Seed(ModelBuilder modelBuilder)
        {

            DataSeederService _dataSeederService = new DataSeederService();

            matches = _dataSeederService.CreateMatches();

            modelBuilder.Entity<Match>().HasData(matches);
        }
    }
}
