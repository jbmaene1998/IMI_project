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
    public class JobController : Controller
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        /// <summary>
        /// Get all jobs
        /// </summary>
        [ProducesResponseType(200)]
        [Produces("application/json")]
        [HttpGet]
        [Authorize(Roles = "Admin,Student,Recruiter")]
        //[Authorize(Policy = "CanRead")]
        public IActionResult Get()
        {
            var jobs = _jobService.GetAll();
            return Ok(jobs);
        }
        /// <summary>
        /// Get a job by id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Student,Recruiter")]
        public async Task<IActionResult> Get(string id)
        {
            var job = await _jobService.GetByIdAsync(id);
            return job == null ? (IActionResult) NotFound($"job with ID {id} does not exist") : Ok(job);
        }
        /// <summary>
        /// Add a job
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        //[Authorize(Policy = "CanCreate")]
        public async Task<IActionResult> Add(JobRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jobResponseDto = await _jobService.AddAsync(requestDto);
            return Ok(jobResponseDto);
        }
        /// <summary>
        /// Delete a job
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        //[Authorize(Policy = "CanDelete")]

        public async Task<IActionResult> Delete(string id)
        {
            var job = _jobService.GetByIdAsync(id);
            if (job == null)
            {
                return NotFound($"Job with ID {id} does not exist");
            }
            await _jobService.DeleteAsync(id);
            return Ok();
        }
    }
}
