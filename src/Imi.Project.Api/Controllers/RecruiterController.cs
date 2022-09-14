using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Helper;
using Imi.Project.Api.Core.Interfaces.Images;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Imi.Project.Api.Core.Entities.BaseEntities;
using System.Collections.Generic;

namespace Imi.Project.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecruiterController : Controller
    {
        private readonly IRecruiterService _recruiterService;
        private readonly IStudentService _studentService;
        private readonly IImageService _imageService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public RecruiterController(IRecruiterService recruiterService, 
            IStudentService studentService, 
            IImageService imageService, 
            IMapper mapper,
            IUserService userService
            )
        {
            _recruiterService = recruiterService;
            _studentService = studentService;
            _imageService = imageService;
            _mapper = mapper;
            _userService = userService;
        }
        /// <summary>
        /// Register a recruiter
        /// </summary>
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRecruiterRequestDto registrationDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var result = await _recruiterService.AddAsync(registrationDto);

            switch (result)
            {
                case true:
                    return Ok();
                case false:
                    return BadRequest("Something went wrong. Registration is not of type RegisterRecruiterRequestDto");
                default:
                    foreach (var error in result)
                    {
                        ModelState.AddModelError(error.Key, error.Value);
                    }
                    return BadRequest(ModelState);
            }
        }
        /// <summary>
        /// Get a recruiter by id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Student,Recruiter")]
        //[Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get(string id)
        {
            var recruiter = await _recruiterService.GetByIdAsync(id);
            return recruiter is null ? NotFound($"Recruiter with ID {id} does not exist") : (IActionResult)Ok(recruiter);
        }
        /// <summary>
        /// Get all potential recruiters for student by student id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpGet("{studentId}/students")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetAllForStudent(string studentId)
        {
            var studentCheck = await _studentService.GetByIdAsync(studentId);
            if (studentCheck is null)
            {
                return NotFound($"Student with ID {studentId} does not exist");
            }
            var includes = new[] { "Location", "Company"};
            var recruiter = await _recruiterService.GetAllForStudentAsync(studentId, includes);
            return Ok(recruiter);
        }
        /// <summary>
        /// Update/Modify a recruiter
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpPut]
        [Authorize(Roles = "Admin,Recruiter")]
        [Authorize(Policy = "CanEdit")]
        public async Task<IActionResult> Update(RecruiterRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var recruiterResponseDto = await _recruiterService.UpdateAsync(requestDto);
            return Ok(recruiterResponseDto);
        }
        /// <summary>
        /// Delete a recruiter by id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> Delete(string id)
        {
            var recruiter = _recruiterService.GetByIdAsync(id);
            if (recruiter == null)
            {
                return NotFound($"Recruiter with ID {id} does not exist");
            }
            await _recruiterService.DeleteAsync(id);
            return Ok();
        }
        /// <summary>
        /// Save/Update an image
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [HttpPost("{id}/image")]
        [Authorize(Roles = "Recruiter")]
        public async Task<IActionResult> AddOrUpdateImage(string id, IFormFile image)
        {
            if (image is null)
            {
                return BadRequest($"Image can't be empty");
            }
            var recruiter = await _recruiterService.GetByIdAsync(id);
            if (recruiter is null)
            {
                return NotFound($"Recruiter with ID {id} does not exist");
            }

            recruiter.ImageUrl = await _imageService.AddOrUpdateImageAsync<Recruiter>(id, image);

            await _recruiterService.UpdateAsync(_mapper.DtoMapper(recruiter));
            return Ok(recruiter);
        }
    }
}
