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
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        /// <summary>
        /// Get all continents
        /// </summary>
        [ProducesResponseType(200)]
        [Produces("application/json")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var locations = await _locationService.GetAllContinentsAsync();
            return Ok(locations);
        }
        /// <summary>
        /// Get all countries by continent
        /// </summary>
        [ProducesResponseType(200)]
        [Produces("application/json")]
        [HttpGet("{continentString}/countries")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCountries(string continentString)
        {
            var locations = await _locationService.GetAllCountriesByContinentAsync(continentString);
            return Ok(locations);
        }
        /// <summary>
        /// Get all cities by continent and country
        /// </summary>
        [ProducesResponseType(200)]
        [Produces("application/json")]
        [HttpGet("{continentString}/{countryString}/cities")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCities(string continentString, string countryString)
        {
            var locations = await _locationService.GetAllCitiesByCountryAsync(continentString, countryString);
            return Ok(locations);
        }
        /// <summary>
        /// Get a location by id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string id)
        {
            var location = await _locationService.GetByIdAsync(id);
            if (location is null)
            {
                return NotFound($"Location with ID {id} doesn't exists.");
            }
            return Ok(location);
        }
        /// <summary>
        /// Add a location
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(LocationRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var locationResponseDto = await _locationService.AddAsync(requestDto);
            return Ok(locationResponseDto);
        }
        /// <summary>
        /// Update/Modify a location
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(LocationRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var locationResponseDto = await _locationService.UpdateAsync(requestDto);
            return Ok(locationResponseDto);
        }
        /// <summary>
        /// Delete a location by id
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            var location = _locationService.GetByIdAsync(id);
            if (location == null)
            {
                return NotFound($"Location with ID {id} does not exist");
            }
            await _locationService.DeleteAsync(id);
            return Ok(location);
        }
    }

}
