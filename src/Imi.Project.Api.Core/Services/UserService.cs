using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.BaseEntities;
using Imi.Project.Api.Core.Interfaces.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<BasePerson> _userManager;
        private readonly SignInManager<BasePerson> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository<BasePerson, BasePersonDto> _userRepository;

        public UserService(IMapper mapper, 
            UserManager<BasePerson> userManager,
            SignInManager<BasePerson> signInManager,
            IConfiguration configuration,
            IUserRepository<BasePerson, BasePersonDto> userRepository
            )
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<JwtSecurityToken> GenerateTokenAsync(dynamic user)
        {
                var claims = new List<Claim>();

                // Loading the user Claims
                var userClaims = await _userManager.GetClaimsAsync(user);

                claims.AddRange(userClaims);

                // Loading the roles and put them in a claim of a Role ClaimType
                var roleClaims = await _userManager.GetRolesAsync(user);
                foreach (var roleClaim in roleClaims)
                {
                    claims.Add(new Claim(ClaimTypes.Role, roleClaim));
                }

                var expirationDays = _configuration.GetValue<int>("JWTConfiguration:TokenExpirationDays");
                var siginingKey = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTConfiguration:SigningKey"));
                var token = new JwtSecurityToken
                (
                    issuer: _configuration.GetValue<string>("JWTConfiguration:Issuer"),
                    audience: _configuration.GetValue<string>("JWTConfiguration:Audience"),
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromDays(expirationDays)),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(siginingKey), SecurityAlgorithms.HmacSha256)
                );

                return token;
        }
        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto requestDto)
        {
            var result = await _userRepository.LoginAsync(requestDto);
            switch (result)
            {
                case false:
                    return null;
                default:
                    var user = await _userManager.FindByEmailAsync(requestDto.Email);

                    JwtSecurityToken token = await GenerateTokenAsync(user);

                    string serializedToken = new JwtSecurityTokenHandler().WriteToken(token);

                    bool isRecruiter = false;

                    if (user is Recruiter) isRecruiter = true;

                    LoginResponseDto dto = new LoginResponseDto()
                    {
                        Token = serializedToken,
                        Id = user.Id,
                        IsRecruiter = isRecruiter,
                        IsAdmin = user.IsAdmin
                    };

                    return dto;
            }
        }
    }
}
