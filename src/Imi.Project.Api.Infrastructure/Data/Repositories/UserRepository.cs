using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.BaseEntities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Data.Repositories
{
    public class UserRepository<T, K> : IUserRepository<T, K> where T : BasePerson where K : BasePersonDto
    {

        protected readonly ITInternshipsContextDb DbContext;
        protected readonly UserManager<BasePerson> _userManager;
        protected readonly SignInManager<BasePerson> _signInManager;
        protected readonly ILocationRepository _locationRepository;

        public UserRepository(ITInternshipsContextDb dbContext, UserManager<BasePerson> userManager, SignInManager<BasePerson> signInManager, ILocationRepository locationRepository)
        {
            DbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _locationRepository = locationRepository;
        }

        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>().AsNoTracking().Where(b => b is T);
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdAsync(string id, string[] includes)
        {
            var query = DbContext.Set<T>().AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.SingleOrDefaultAsync(t => t.Id.Equals(id));
        }

        public IQueryable<T> GetAllByIdAsync(string id, string[] includes)
        {
            var query = DbContext.Set<T>().AsQueryable();
            return includes.Aggregate(query, (current, include) => current.Include(include));
        }

        public async Task<IdentityResult> AddAsync(T entity, K Dto)
        {
            var result = await _userManager.CreateAsync(entity, (Dto).Password);
            var location = _locationRepository.GetByIdAsync(entity.LocationId).Result;
            await _userManager.AddClaimAsync(entity, new Claim("country-of-residence", location.City));
            return result;
        }
        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> UpdateAsync(T entity)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(entity.Id);
                user.Id = entity.Id;
                user.Email = entity.Email;
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.UserName = entity.UserName;
                user.NormalizedUserName = entity.NormalizedUserName;
                user.PhoneNumber = entity.PhoneNumber;
                user.NormalizedEmail = entity.NormalizedEmail;
                user.EmailConfirmed = entity.EmailConfirmed;
                user.LocationId = entity.LocationId;
                user.ImageUrl = entity.ImageUrl;

                return await _userManager.UpdateAsync(user);            
            }
            catch (Exception)
            {

                throw;
            }
        }

        Task<T> IRepository<T>.UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> DeleteAsync(string id)
        {
            var entity = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(entity);
            return entity as T;
        }
        public async Task<IEnumerable<Student>> GetAllForRecruiter(string recruiterId, string[] includes)
        {
            var recIncludes = new[] { "Location" };

            var reQuery = DbContext.Set<Recruiter>().AsQueryable();

            reQuery = recIncludes.Aggregate(reQuery, (current, include) => current.Include(include));

            var recruiter = await reQuery.SingleOrDefaultAsync(t => t.Id.Equals(recruiterId));

            var query = DbContext.Set<Student>().AsQueryable();

            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.ToList().Where(q => q.Location.Country == recruiter.Location.Country);

        }

        public async Task<Student> GetByIdIncludeSchoolLocation(string id)
        {
            var query = DbContext.Set<Student>().AsQueryable();
            return await query
                .Include(q => q.Location)
                .Include(q => q.Job)
                .Include(q => q.School)
                .ThenInclude(c => c.Location)
                .SingleOrDefaultAsync(t => t.Id.Equals(id));
        }

        public async Task<bool> LoginAsync(LoginRequestDto requestDto)
        {
            var loggedInUser = await _userManager.FindByEmailAsync(requestDto.Email);
            if (loggedInUser is null)
            {
                return false;
            }
            var result = await _signInManager.PasswordSignInAsync(loggedInUser.UserName, requestDto.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<Recruiter>> GetAllForStudent(string studentId, string[] includes)
        {
            var studIncludes = new[] { "Location" };

            var stuQuery = DbContext.Set<Student>().AsQueryable();

            stuQuery = studIncludes.Aggregate(stuQuery, (current, include) => current.Include(include));

            var student = await stuQuery.SingleOrDefaultAsync(t => t.Id.Equals(studentId));

            var query = DbContext.Set<Recruiter>().AsQueryable();

            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.ToList().Where(q => q.Location.Country == student.Location.Country);
        }

        public async Task<Recruiter> GetByIdIncludeCompanyLocation(string id)
        {
            var query = DbContext.Set<Recruiter>().AsQueryable();
            return await query
                .Include(q => q.Location)
                .Include(q => q.Company)
                .ThenInclude(c => c.Location)
                .SingleOrDefaultAsync(t => t.Id.Equals(id));
        }
    }
}
