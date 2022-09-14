using System;
using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Dtos
{
    public class MatchResponseDto : DtoBase
    {
        public string RecruiterId { get; set; }
        public string StudentId { get; set; }
        public Recruiter Recruiter { get; set; }
        public Student Student { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
