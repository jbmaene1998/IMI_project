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
    public class LikeController : Controller
    {
        private readonly ILikeService _likeService;
        private readonly IRecruiterService _recruiterService;
        private readonly IStudentService _studentService;

        public LikeController(ILikeService likeService, IRecruiterService recruiterService, IStudentService studentService)
        {
            _likeService = likeService;
            _recruiterService = recruiterService;
            _studentService = studentService;
        }
        /// <summary>
        /// Get all likes from a student by id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpGet("{studentId}/students")]
        [Authorize(Roles = "Recruiter")]
        public async Task<IActionResult> GetFromStudents(string studentId)
        {
            var recruiter = await _studentService.GetByIdAsync(studentId);
            if (recruiter == null)
            {
                return NotFound($"Student with ID {studentId} does not exist");
            }
            var likes = await _likeService.GetAllFromStudentAsync(studentId);
            return Ok(likes);
        }
        /// <summary>
        /// Get all likes from a recruiter by id 
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpGet("{recruiterId}/recruiters")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetFromRecruiters(string recruiterId)
        {
            var recruiter = await _recruiterService.GetByIdAsync(recruiterId);
            if (recruiter == null)
            {
                return NotFound($"Recruiter with ID {recruiterId} does not exist");
            }
            var likes = await _likeService.GetAllFromRecruiterAsync(recruiterId);
            return Ok(likes);
        }
        /// <summary>
        /// Add a like
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpPost]
        [Authorize(Roles = "Student,Recruiter")]
        public async Task<IActionResult> Add(LikeRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var companyResponseDto = await _likeService.AddAsync(requestDto);
            return Ok(companyResponseDto);
        }
    }
}
