using System;
using System.Collections.Generic;
using System.Text;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Imi.Project.Api.Infrastructure.Data.DataSeeders
{
    public class RecruiterLikeSeeder
    {
        static List<Like> recruiterLikes;
        public RecruiterLikeSeeder()
        {
        }
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>().HasKey(s => new { s.StudentId, s.RecruiterId });

            modelBuilder.Entity<Like>()
                .HasOne(s => s.Student)
                .WithMany(s => s.Likes)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
                .HasOne(s => s.Recruiter)
                .WithMany(s => s.Likes)
                .HasForeignKey(s => s.RecruiterId)
                .OnDelete(DeleteBehavior.NoAction);

            DataSeederService _dataSeederService = new DataSeederService();

            recruiterLikes = _dataSeederService.CreateLikes();

            modelBuilder.Entity<Like>().HasData(recruiterLikes);
        }
    }
}
