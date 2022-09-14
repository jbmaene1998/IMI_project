using System;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchoolController : Controller
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }
        /// <summary>
        /// Get all schools
        /// </summary>
        [ProducesResponseType(200)]
        [Produces("application/json")]
        [HttpGet]
        [Authorize(Roles = "Admin,Student,Recruiter")]
        public async Task<IActionResult> Get()
        {
            var companies = await _schoolService.GetAllAsync();
            return Ok(companies);
        }
        /// <summary>
        /// Get school by id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Student,Recruiter")]
        //[Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get(string id)
        {
            var company = await _schoolService.GetByIdAsync(id);
            return company is null ? (IActionResult) NotFound($"School with ID {id} does not exist") : Ok(company);
        }
        /// <summary>
        /// Add a school
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpPost]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> Add(SchoolRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var companyResponseDto = await _schoolService.AddAsync(requestDto);
            return Ok(companyResponseDto);
        }
        /// <summary>
        /// Update/Modify a school
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(SchoolRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var companyResponseDto = await _schoolService.UpdateAsync(requestDto);
            return Ok(companyResponseDto);
        }
        /// <summary>
        /// Delete a school by id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            var school = _schoolService.GetByIdAsync(id);
            if (school == null)
            {
                return NotFound($"School with ID {id} does not exist");
            }
            await _schoolService.DeleteAsync(id);
            return Ok();
        }
    }
}
