using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;

namespace Imi.Project.Api.Core.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public JobService(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }
        public async Task<JobResponseDto> AddAsync(JobRequestDto requestDto)
        {
            var result = await _jobRepository.AddAsync(_mapper.DtoMapper(requestDto));
            return _mapper.DtoMapper(result);
        }

        public async Task DeleteAsync(string id)
        {
            await _jobRepository.DeleteAsync(id);
        }

        public IEnumerable<JobResponseDto> GetAll()
        {
            var results = _jobRepository.GetAll();
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }
        public Task<JobResponseDto> GetByIdAsync(string id)
        {
            var result = _jobRepository.GetAll()
                .SingleOrDefault(a => a.Id == id);
            return Task.FromResult(_mapper.DtoMapper(result));
        }

        public async Task<JobResponseDto> UpdateAsync(JobRequestDto requestDto)
        {
            var result = await _jobRepository.UpdateAsync(_mapper.DtoMapper(requestDto));
            return _mapper.DtoMapper(result);
        }
    }
}
