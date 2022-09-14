using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace Imi.Project.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessagesController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IStudentService _studentService;
        private readonly IRecruiterService _recruiterService;

        public MessagesController(IMessageService messageService, IStudentService studentService, IRecruiterService recruiterService)
        {
            _messageService = messageService;
            _studentService = studentService;
            _recruiterService = recruiterService;
        }
        /// <summary>
        /// Get all messages between a student and a recruiter for a student
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpGet("{studentId}/students/{recruiterId}")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetFromStudent(string studentId, string recruiterId)
        {
            var recruiter = await _recruiterService.GetByIdAsync(recruiterId);
            if (recruiter is null)
            {
                return NotFound($"recruiter with ID {recruiterId} doesn't exists.");
            }
            var student = await _studentService.GetByIdAsync(studentId);
            if (student is null)
            {
                return NotFound($"Student with ID {studentId} doesn't exists.");
            }
            var messages = await _messageService.GetAllFromStudentAsync(studentId, recruiterId);
            return Ok(messages);
        }
        /// <summary>
        /// Get all messages between a student and a recruiter for a recruiter
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpGet("{recruiterId}/recruiters/{studentId}")]
        [Authorize(Roles = "Recruiter")]
        public async Task<IActionResult> GetFromRecruiter(string recruiterId, string studentId)
        {
            var recruiter = await _recruiterService.GetByIdAsync(recruiterId);
            if (recruiter is null)
            {
                return NotFound($"recruiter with ID {recruiterId} doesn't exists.");
            }
            var student = await _studentService.GetByIdAsync(studentId);
            if (student is null)
            {
                return NotFound($"Student with ID {studentId} doesn't exists.");
            }
            var messages = await _messageService.GetAllFromStudentAsync(recruiterId, studentId);
            return Ok(messages);
        }
        /// <summary>
        /// Add a message
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "Student,Recruiter")]
        //[Authorize(Policy = "OnlyCitizensNotFromNorthKorea")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> Add(MessageRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var messageResponseDto = await _messageService.AddAsync(requestDto);
            return Ok(messageResponseDto);
        }
    }
}
