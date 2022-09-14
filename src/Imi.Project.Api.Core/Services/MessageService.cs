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
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }
        public async Task<MessageResponseDto> AddAsync(MessageRequestDto requestDto)
        {
            var test = _mapper.DtoMapper(requestDto);
            var result = await _messageRepository.AddAsync(test);
            return _mapper.DtoMapper(result);
        }

        public async Task<IEnumerable<MessageResponseDto>> GetAllAsync()
        {
            var results = _messageRepository.GetAll();
            return results.Select(result => _mapper.DtoMapper(result)).ToList();
        }

        public async Task<IEnumerable<MessageResponseDto>> GetAllFromRecruiterAsync(string recruiterId, string studentId)
        {
            var messages = _messageRepository.GetAllFromRecruiter(recruiterId, studentId);
            return messages.Select(message => _mapper.DtoMapper(message)).ToList();
        }

        public async Task<IEnumerable<MessageResponseDto>> GetAllFromStudentAsync(string studentId, string recruiterId)
        {
            var messages = _messageRepository.GetAllFromStudent(studentId, recruiterId);
            return messages.Select(message => _mapper.DtoMapper(message)).ToList();
        }
    }
}
