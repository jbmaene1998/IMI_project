using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.BaseEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IUserRepository<T, K> : IRepository<T> where T : BasePerson
    {
        Task<IdentityResult> AddAsync(T entity, K Dto);
        Task<IdentityResult> UpdateAsync(T entity);
        Task<bool> LoginAsync(LoginRequestDto requestDto);
        Task<IEnumerable<Student>> GetAllForRecruiter(string recruiterId, string[] includes);
        Task<Recruiter> GetByIdIncludeCompanyLocation(string id);
        Task<Student> GetByIdIncludeSchoolLocation(string id);
        Task<IEnumerable<Recruiter>> GetAllForStudent(string studentId, string[] includes);
    }
}
