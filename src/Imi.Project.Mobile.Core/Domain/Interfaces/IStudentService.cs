using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Imi.Project.Mobile.Core.Modals;

namespace Imi.Project.Mobile.Core.Domain.Interfaces
{
    public interface IStudentService
    {
        Task<IQueryable<Student>> GetAll();
        Task<Student> GetById(string id);
        Task<Student> Add(Student student);
        Task<Student> Update(Student student);
        Task<Student> Delete(string id);
    }
}
