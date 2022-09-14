using Imi.Project.Mobile.Core.Domain.Interfaces;
using Imi.Project.Mobile.Core.Modals.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Domain.Services.Mocking
{
    public class MockUserService : IUserService
    {
        private readonly IStudentService _studentService;
        private readonly IRecruiterService _recruiterService;
        public MockUserService()
        {
            _studentService = new MockStudentService();
            _recruiterService = new MockRecruiterService();
        }
        public async Task<BasePerson> Validate(string email, string password)
        {
            var recruiters = await _recruiterService.GetAll();
            var students = await _studentService.GetAll();
            List<BasePerson> users = new List<BasePerson>();
            users.AddRange((IEnumerable<BasePerson>)recruiters);
            users.AddRange((IEnumerable<BasePerson>)students);

            var user = users.FirstOrDefault(u => u.Email == email);
            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }
    }
}
