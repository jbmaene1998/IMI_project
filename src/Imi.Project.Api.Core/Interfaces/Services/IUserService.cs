using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<JwtSecurityToken> GenerateTokenAsync(dynamic user);
        Task<LoginResponseDto> LoginAsync(LoginRequestDto requestDto);
    }
}
