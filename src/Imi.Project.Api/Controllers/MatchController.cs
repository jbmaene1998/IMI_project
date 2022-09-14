using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Services;

namespace Imi.Project.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;
        private readonly IStudentService _studentService;
        private readonly IRecruiterService _recruiterService;

        public MatchController(IMatchService matchService, IStudentService studentService, IRecruiterService recruiterService)
        {
            _matchService = matchService;
            _studentService = studentService;
            _recruiterService = recruiterService;
        }
        /// <summary>
        /// Get all matches from a student by student id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpGet("students/{studentId}")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetByStudent(string studentId)
        {
            var student = await _studentService.GetByIdAsync(studentId);
            if (student is null)
            {
                return NotFound($"Student with ID {studentId} doesn't exists.");
            }
            var matches = await _matchService.GetMatchesByStudentAsync(studentId);
            return Ok(matches);
        }
        /// <summary>
        /// Get all matches from a recruiter by recruiter id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpGet("recruiter/{recruiterId}")]
        [Authorize(Roles="Recruiter")]
        //[Authorize(Policy = "CanRead")]
        public async Task<IActionResult> GetByRecruiter(string recruiterId)
        {
            var student = await _recruiterService.GetByIdAsync(recruiterId);
            if (student is null)
            {
                return NotFound($"Student with ID {recruiterId} doesn't exists.");
            }
            var matches = await _matchService.GetMatchesByRecruiterAsync(recruiterId);
            return Ok(matches);
        }
        /// <summary>
        /// Add a match
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpPost]
        [Authorize(Roles = "Recruiter,Student")]
        public async Task<IActionResult> Add(MatchRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jobResponseDto = await _matchService.AddAsync(requestDto);
            return Ok(jobResponseDto);
        }
    }
}
