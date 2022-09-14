using Imi.Project.Api.Core.Dtos.Base;
using System;

namespace Imi.Project.Api.Core.Dtos
{
    public class LikeResponseDto : DtoBase
    {
        public string StudentId { get; set; }
        public string RecruiterId { get; set; }
        public bool IsRecruiter { get; set; }
    }
}
