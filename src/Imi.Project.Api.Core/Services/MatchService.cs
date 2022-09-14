using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;

namespace Imi.Project.Api.Core.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public MatchService(IMatchRepository matchRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }
        public async Task<MatchResponseDto> AddAsync(MatchRequestDto requestDto)
        {
            var result = await _matchRepository.AddAsync(_mapper.DtoMapper(requestDto));
            return _mapper.DtoMapper(result);
        }

        public async Task DeleteAsync(string id)
        {
            await _matchRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<MatchResponseDto>> GetAllAsync()
        {
            var results = _matchRepository.GetAll();
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }
        public Task<MatchResponseDto> GetByIdAsync(string id)
        {
            var result = _matchRepository.GetAll()
                .SingleOrDefault(a => a.Id == id);
            return Task.FromResult(_mapper.DtoMapper(result));
        }

        public async Task<IEnumerable<MatchResponseDto>> GetMatchesByRecruiterAsync(string id)
        {
            var results = _matchRepository.GetMatchesByRecruiter(id);
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }

        public async Task<IEnumerable<MatchResponseDto>> GetMatchesByStudentAsync(string id)
        {
            var results = _matchRepository.GetMatchesByStudent(id);
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }
    }
}
