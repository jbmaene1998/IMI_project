using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;

namespace Imi.Project.Api.Core.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly IVacancyRepository _vacancyRepository;
        private readonly IMapper _mapper;

        public VacancyService(IVacancyRepository vacancyRepository, IMapper mapper)
        {
            _vacancyRepository = vacancyRepository;
            _mapper = mapper;
        }
        public async Task<VacancyResponseDto> AddAsync(VacancyRequestDto requestDto)
        {
            var result = await _vacancyRepository.AddAsync(_mapper.DtoMapper(requestDto));
            return _mapper.DtoMapper(result);
        }

        public async Task DeleteAsync(string id)
        {
            await _vacancyRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<VacancyResponseDto>> GetAllAsync()
        {
            var results = _vacancyRepository.GetAll();
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }

        public async Task<IEnumerable<VacancyResponseDto>> GetAllByRecruiterAsync(string recruiterId)
        {
            var includes = new[] {"Recruiter"};
            var results =  _vacancyRepository.GetAllByIdAsync(recruiterId, includes).Where(x => x.RecruiterId == recruiterId);
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }

        public Task<VacancyResponseDto> GetByIdAsync(string id)
        {
            var result = _vacancyRepository.GetAll()
                .SingleOrDefault(a => a.Id == id);
            return Task.FromResult(_mapper.DtoMapper(result));
        }
    }
}
