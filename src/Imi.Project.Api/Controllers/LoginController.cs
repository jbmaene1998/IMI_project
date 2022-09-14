using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Login as user
        /// </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginRequestDto requestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (requestDto.Email == null || requestDto.Password == null ) return BadRequest("Email or password can't be null.");

            var result = await _userService.LoginAsync(requestDto);

            switch (result)
            {
                case null:
                    return BadRequest("Login credentials are incorrect");
                default:
                    return Ok(result);
            }
        }
    }
}
