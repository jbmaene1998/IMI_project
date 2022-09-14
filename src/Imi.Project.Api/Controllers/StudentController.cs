using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Helper;
using Imi.Project.Api.Core.Interfaces.Images;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Imi.Project.Api.Core.Helpers;
using Imi.Project.Api.Core.Entities.BaseEntities;
using System.Security.Claims;

namespace Imi.Project.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly UserManager<BasePerson> _userManager;
        private readonly IStudentService _studentService;
        private readonly IRecruiterService _recruiterService;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService,
            IImageService imageService,
            IMapper mapper,
            UserManager<BasePerson> userManager,
            IRecruiterService recruiterService
            )
        {
            _recruiterService = recruiterService;
            _studentService = studentService;
            _imageService = imageService;
            _mapper = mapper;
            _userManager = userManager;
        }
        /// <summary>
        /// Register a student
        /// </summary>
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterStudentRequestDto registrationDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            if (registrationDto is RegisterStudentRequestDto)
            {
                var newUser = _mapper.DtoMapper(registrationDto);
                IdentityResult result = await _userManager.CreateAsync(newUser, (registrationDto).Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                return Ok();
            }
            return BadRequest("Something went wrong. Registration is not of type RegisterRecruiterRequestDto");
        }
        /// <summary>
        /// Get a student by id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Recruiter,Student")]
        //[Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get(string id)
        {
            var student = await _studentService.GetByIdAsync(id);
            return student is null ? BadRequest($"Student with ID {id} doesn't exists.") : (IActionResult)Ok(student);
        }
        /// <summary>
        /// Get all potential students for recruiter by recruiter id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpGet("{studentId}/students")]
        [Authorize( Roles = "Recruiter")]
        //[Authorize(Policy = "CanRead")]
        public async Task<IActionResult> GetAllForRecruiter(string studentId)
        {
            var studentCheck = await _recruiterService.GetByIdAsync(studentId);
            if (studentCheck == null)
            {
                return NotFound($"Student with ID {studentId} does not exist");
            }
            var includes = new[] { "Location", "School" };
            var recruiters = await _studentService.GetAllForRecruiterAsync(studentId, includes);
            return Ok(recruiters);
        }
        /// <summary>
        /// Update/Modify a student
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpPut]
        [Authorize(Roles = "Student")]
        //[Authorize(Policy = "CanEdit")]
        public async Task<IActionResult> Update(StudentRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var studentResponseDto = await _studentService.UpdateAsync(requestDto);
            return Ok(studentResponseDto);
        }
        /// <summary>
        /// Delete a student by ID
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(string id)
        {
            var student = _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} does not exist");
            }
            await _studentService.DeleteAsync(id);
            return Ok();
        }

        /// <summary>
        /// Save/Update an image
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [HttpPost("{id}/image")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> AddOrUpdateImage(string id, IFormFile image)
        {
            if (image is null)
            {
                return BadRequest($"Image can't be empty");
            }
            var student = await _studentService.GetByIdAsync(id);
            if (student is null)
            {
                return NotFound($"Student with ID {id} does not exist");
            }
            student.ImageUrl = await _imageService.AddOrUpdateImageAsync<Student>(id, image);
            await _studentService.UpdateAsync(_mapper.DtoMapper(student));
            return Ok(student);
        }
    }
}

