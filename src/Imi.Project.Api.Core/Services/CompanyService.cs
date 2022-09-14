using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;

namespace Imi.Project.Api.Core.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompanyService(ICompanyRepository companyService, IMapper mapper)
        {
            _mapper = mapper;
            _companyRepository = companyService;
        }

        public async Task<CompanyResponseDto> AddAsync(CompanyRequestDto requestDto)
        {
            var result = await _companyRepository.AddAsync(_mapper.DtoMapper(requestDto));
            return _mapper.DtoMapper(result);
        }

        public async Task DeleteAsync(string id)
        {
            await _companyRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CompanyResponseDto>> GetAllAsync()
        {
            var results = _companyRepository.GetAll();
            var responseDtos = new List<CompanyResponseDto>();
            foreach (var result in results)
            {
                responseDtos.Add(_mapper.DtoMapper(result));
            }
            return responseDtos;
        }

        public async Task<CompanyResponseDto> GetByIdAsync(string id)
        {
            var includes = new[] {"Location"};
            var result = await _companyRepository.GetByIdAsync(id, includes);
            return _mapper.DtoMapper(result);
        }

        public async Task<CompanyResponseDto> UpdateAsync(CompanyRequestDto requestDto)
        {
            var result = await _companyRepository.UpdateAsync(_mapper.DtoMapper(requestDto));
            return _mapper.DtoMapper(result);
        }
    }
}
