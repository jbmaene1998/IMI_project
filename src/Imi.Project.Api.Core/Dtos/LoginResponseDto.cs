using Imi.Project.Api.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string Id { get; set; }
        public bool IsRecruiter { get; set; }
        public bool IsAdmin { get; set; }
    }
}
