using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;

namespace Imi.Project.Api.Core.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;

        public SchoolService(ISchoolRepository schoolRepository, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }
        public async Task<SchoolResponseDto> AddAsync(SchoolRequestDto requestDto)
        {
            var result = await _schoolRepository.AddAsync(_mapper.DtoMapper(requestDto));
            return _mapper.DtoMapper(result);
        }

        public async Task DeleteAsync(string id)
        {
            await _schoolRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SchoolResponseDto>> GetAllAsync()
        {
            var results = _schoolRepository.GetAll();
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }

        public Task<SchoolResponseDto> GetByIdAsync(string id)
        {
            var result = _schoolRepository.GetAll()
                .SingleOrDefault(a => a.Id == id);
            return Task.FromResult(_mapper.DtoMapper(result));
        }

        public async Task<SchoolResponseDto> UpdateAsync(SchoolRequestDto requestDto)
        {
            var result = await _schoolRepository.UpdateAsync(_mapper.DtoMapper(requestDto));
            return _mapper.DtoMapper(result);
        }
    }
}
