using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Imi.Project.Api.Core.Interfaces.Services;

namespace Imi.Project.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly ILocationService _locationService;

        public SearchController(ISearchService searchService, ILocationService locationService)
        {
            _searchService = searchService;
            _locationService = locationService;
        }
        /// <summary>
        /// Search for a company
        /// </summary>
        [ProducesResponseType(200)]
        [Produces("application/json")]
        [HttpGet("{searchCompanyQuery}/companies")]
        [AllowAnonymous]
        //[Authorize(Policy = "CanRead")]
        public async Task<IActionResult> SearchCompany(string searchCompanyQuery)
        {
            return Ok( await _searchService.SearchCompanyAsync(searchCompanyQuery));
        }
        /// <summary>
        /// Search for a job
        /// </summary>
        [ProducesResponseType(200)]
        [Produces("application/json")]
        [HttpGet("{searchJobQuery}/jobs")]
        [AllowAnonymous]
        //[Authorize(Policy = "CanRead")]
        public async Task<IActionResult> SearchJob(string searchJobQuery)
        {
            return Ok(await _searchService.SearchJobAsync(searchJobQuery));
        }
        /// <summary>
        /// Search for a school
        /// </summary>
        [ProducesResponseType(200)]
        [Produces("application/json")]
        [HttpGet("{searchSchoolQuery}/schools")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchSchool(string searchSchoolQuery)
        {
            return Ok(await _searchService.SearchSchoolAsync(searchSchoolQuery));
        }
        /// <summary>
        /// Search for a city
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpGet("{searchCityQuery}/{countryString}/{continentString}/cities")]
        [AllowAnonymous]
        //[Authorize(Policy = "CanRead")]
        public async Task<IActionResult> SearchCity(string searchCityQuery, string countryString, string continentString)
        {
            var continentStringCheck = await _locationService.GetAllCountriesByContinentAsync(continentString);
            if (continentStringCheck is null)
            {
                return BadRequest($"The given continent is incorrect");
            }
            var countryCheck = await _locationService.GetAllCitiesByCountryAsync(continentString,countryString);
            if (countryCheck is null)
            {
                return BadRequest($"The given country is incorrect");
            }
            return Ok(await _searchService.SearchLocationAsync(searchCityQuery, continentString, countryString));
        }
    }
}
