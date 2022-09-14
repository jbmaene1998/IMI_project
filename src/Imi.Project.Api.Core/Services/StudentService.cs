using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.BaseEntities;
using Imi.Project.Api.Core.Interfaces.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace Imi.Project.Api.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository<BasePerson, BasePersonDto> _userRepository;
        private readonly UserManager<BasePerson> _userManager;

        public StudentService(IMapper mapper, IUserRepository<BasePerson, BasePersonDto> userRepository, UserManager<BasePerson> userManager)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<dynamic> AddAsync(RegisterStudentRequestDto requestDto)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();
            if (requestDto is RegisterStudentRequestDto)
            {
                var newUser = _mapper.DtoMapper(requestDto);
                IdentityResult result = await _userManager.CreateAsync(newUser, (requestDto).Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        errors.Add(error.Code, error.Description);
                    }
                    return errors;
                }
                await _userManager.AddClaimAsync(newUser, new Claim("country-of-residence", newUser.Location.Country));
                return true;
            }
            return false;
        }

        public async Task DeleteAsync(string id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StudentResponseDto>> GetAllForRecruiterAsync(string recruiterId, string[] includes)
        {
            var results = await _userRepository.GetAllForRecruiter(recruiterId, includes);
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }

        public async Task<StudentResponseDto> GetByIdAsync(string id)
        {
            var result = await _userRepository.GetByIdIncludeSchoolLocation(id);
            return _mapper.DtoMapper(result);
        }

        public async Task<IdentityResult> UpdateAsync(StudentRequestDto requestDto)
        {
            return await _userRepository.UpdateAsync(_mapper.DtoMapper(requestDto));
        }

        public async Task<IdentityResult> UpdateAsync(Student entity)
        {
            return await _userRepository.UpdateAsync(entity);
        }
    }
}
