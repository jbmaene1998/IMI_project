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
    public class StudentSeeder
    {
        static List<Student> students;
        public StudentSeeder()
        {
        }
        public static void Seed(ModelBuilder modelBuilder)
        {

            DataSeederService _dataSeederService = new DataSeederService();

            students = _dataSeederService.CreateStudents();

            modelBuilder.Entity<Student>().HasData(students);
        }
    }
}
