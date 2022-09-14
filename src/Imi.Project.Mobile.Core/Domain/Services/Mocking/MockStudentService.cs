
using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Domain.Services.Mocking
{
    public class MockStudentService : IStudentService
    {
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                Id = "00000000-0000-0000-0000-000000001000",
                FirstName = "Jens",
                LastName = "NiDalé",
                DateOfBirth = DateTime.Parse("12/12/1999"),
                Email = "jens@student.be",
                Phone = "0496208756",
                ImageUrl = "https://www.thispersondoesnotexist.com/image",
                Password = "password",
                SchoolId = "00000000-0000-0000-0000-000000000001",
                JobId = "00000000-0000-0000-0000-000000010000"
            },
            new Student
            {
                Id = "00000000-0000-0000-0000-000000002000",
                FirstName = "Kjartan",
                LastName = "VanBrugge",
                DateOfBirth = DateTime.Parse("12/12/1967"),
                Email = "kjartan@student.be",
                Phone = "0496208789",
                ImageUrl = "https://www.thispersondoesnotexist.com/image",
                Password = "password",
                SchoolId = "00000000-0000-0000-0000-000000000001",
                JobId = "00000000-0000-0000-0000-000000020000"
            },
            new Student
            {
                Id = "00000000-0000-0000-0000-000000003000",
                FirstName = "Robin",
                LastName = "Vun Reich",
                DateOfBirth = DateTime.Parse("12/12/1959"),
                Email = "robin@student.be",
                Phone = "0496208756",
                ImageUrl = "https://www.thispersondoesnotexist.com/image",
                Password = "password",
                SchoolId = "00000000-0000-0000-0000-000000000002",
                JobId = "00000000-0000-0000-0000-000000030000"
            },
            new Student
            {
                Id = "00000000-0000-0000-0000-000000004000",
                FirstName = "Ellen",
                LastName = "DelSimp",
                DateOfBirth = DateTime.Parse("12/12/1988"),
                Email = "ellen@student.be",
                Phone = "0496208756",
                ImageUrl = "https://www.thispersondoesnotexist.com/image",
                Password = "password",
                SchoolId = "00000000-0000-0000-0000-000000000003",
                JobId = "00000000-0000-0000-0000-000000010000"
            },
        };
        public async Task<Student> Add(Student student)
        {
            students.Add(student);
            return await Task.FromResult(student);
        }

        public async Task<Student> Delete(string id)
        {
            var studentToDelete = students.FirstOrDefault(e => e.Id == id);
            students.Remove(studentToDelete);
            return await Task.FromResult(studentToDelete);
        }

        public async Task<IQueryable<Student>> GetAll()
        {
            var studentList = students.AsQueryable();
            return await Task.FromResult(studentList);
        }

        public async Task<Student> GetById(string id)
        {
            var student = students.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(student);
        }

        public async Task<Student> Update(Student student)
        {
            var studentToUpdate = students.FirstOrDefault(e => e.Id == student.Id);
            students.Remove(studentToUpdate);
            students.Add(student);
            return await Task.FromResult(student);
        }
    }
}
