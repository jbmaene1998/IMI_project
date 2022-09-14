using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Imi.Project.Api.Core.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;

        public LikeService(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }
        public async Task<LikeResponseDto> AddAsync(LikeRequestDto requestDto)
        {
            var result = await _likeRepository.AddAsync(_mapper.DtoMapper(requestDto));
            return _mapper.DtoMapper(result);
        }

        public async Task<IEnumerable<LikeResponseDto>> GetAllAsync()
        {
            var results = await _likeRepository.GetAll().ToListAsync();
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }

        public async Task<IEnumerable<LikeResponseDto>> GetAllFromRecruiterAsync(string id)
        {
            var results = _likeRepository.GetAllFromRecruiterAsync(id);
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }

        public async Task<IEnumerable<LikeResponseDto>> GetAllFromStudentAsync(string id)
        {
            var results = _likeRepository.GetAllFromStudentAsync(id);
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }
    }
}
