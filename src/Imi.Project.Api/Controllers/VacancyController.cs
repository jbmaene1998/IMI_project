using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace Imi.Project.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class VacancyController : Controller
    {
        private readonly IVacancyService _vacancyService;
        private readonly IRecruiterService _recruiterService;

        public VacancyController(IVacancyService vacancyService, IRecruiterService recruiterService)
        {
            _vacancyService = vacancyService;
            _recruiterService = recruiterService;
        }
        /// <summary>
        /// Get all vacancies
        /// </summary>
        [ProducesResponseType(200)]
        [Produces("application/json")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            var results = await _vacancyService.GetAllAsync();
            return Ok(results);
        }
        /// <summary>
        /// Get vacancy by id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(string id)
        {
            var vacancy = await _vacancyService.GetByIdAsync(id);
            return vacancy is null ? (IActionResult) NotFound($"Vacancy with ID {id} does not exist") : Ok(vacancy);
        }
        /// <summary>
        /// Add a vacancy
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpPost]
        [Authorize(Roles = "Recruiter")]
        public async Task<IActionResult> Add(VacancyRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultResponseDto = await _vacancyService.AddAsync(requestDto);
            return Ok(resultResponseDto);
        }
        /// <summary>
        /// Delete a vacancy by id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin, Recruiter")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = _vacancyService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound($"Vacancy with ID {id} does not exist");
            }
            await _vacancyService.DeleteAsync(id);
            return Ok();
        }
        /// <summary>
        /// Get all vacancies from a recruiter by recruiter id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpGet("{recruiterId}/recruiters")]
        [Authorize(Roles ="Admin,Recruiter")]
        public async Task<IActionResult> GetByRecruiter(string recruiterId)
        {
            var recruiter = await _recruiterService.GetByIdAsync(recruiterId);
            if (recruiter == null)
            {
                return NotFound($"Recruiter with ID {recruiterId} does not exist");
            }
            var results = await _vacancyService.GetAllAsync();
            return Ok(results);
        }
    }
}
