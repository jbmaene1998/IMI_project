using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class RecruiterService : IRecruiterService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository<BasePerson, BasePersonDto> _userRepository;
        public RecruiterService(IMapper mapper, IUserRepository<BasePerson, BasePersonDto> recruiterRepository)
        {
            _mapper = mapper;
            _userRepository = recruiterRepository;
        }

        public async Task<dynamic> AddAsync(RegisterRecruiterRequestDto requestDto)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();
            if (requestDto is RegisterRecruiterRequestDto)
            {
                var newUser = _mapper.DtoMapper(requestDto);
                IdentityResult result = await _userRepository.AddAsync(newUser, requestDto);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        errors.Add(error.Code, error.Description);
                    }
                    return errors;
                }
                return true;
            }
            await _userRepository.DeleteAsync(requestDto.Id);
            return false;
        }

        public async Task DeleteAsync(string id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RecruiterResponseDto>> GetAllForStudentAsync(string studentId, string[] includes)
        {
            var results = await _userRepository.GetAllForStudent(studentId, includes);
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }

        public async Task<RecruiterResponseDto> GetByIdAsync(string id)
        {
            var result = await _userRepository.GetByIdIncludeCompanyLocation(id);
            return _mapper.DtoMapper(result);
        }

        public async Task<IdentityResult> UpdateAsync(RecruiterRequestDto requestDto)
        {
            return await _userRepository.UpdateAsync(_mapper.DtoMapper(requestDto));
        }

        public async Task<IdentityResult> UpdateAsync(Recruiter entity)
        {
            return await _userRepository.UpdateAsync(entity);
        }



    }
}
