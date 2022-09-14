using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Services;
using Newtonsoft.Json;
using Imi.Project.Api.Core.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Imi.Project.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _schoolService;

        public CompanyController(ICompanyService companyService)
        {
            _schoolService = companyService;
        }
        /// <summary>
        /// Get all companies
        /// </summary>
        [ProducesResponseType(200)]
        [Produces("application/json")]
        [HttpGet]
        [Authorize(Roles = "Admin,Student,Recruiter")]
        //[Authorize(Policy = "CanRead")]
        public async Task<IActionResult> Get()
        {
            var companies = await _schoolService.GetAllAsync();
            return Ok(companies);
        }
        /// <summary>
        /// Get company by id
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
            return company == null ? (IActionResult) NotFound($"Company with ID {id} does not exist") : Ok(company);
        }
        /// <summary>
        /// Add a company
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpPost]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> Add(CompanyRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var companyResponseDto = await _schoolService.AddAsync(requestDto);
            return Ok(companyResponseDto);
        }
        /// <summary>
        /// Update/Modify company
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(CompanyRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var companyResponseDto = await _schoolService.UpdateAsync(requestDto);
            return Ok(companyResponseDto);
        }
        /// <summary>
        /// Delete a company
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            var company = _schoolService.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound($"Company with ID {id} does not exist");
            }
            await _schoolService.DeleteAsync(id);
            return Ok();
        }
    }
}
