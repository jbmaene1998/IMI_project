using System;
using System.Collections.Generic;
using System.Text;
using Imi.Project.Api.Core.Entities.BaseEntities;

namespace Imi.Project.Api.Core.Entities
{
    public class Like : BaseEntity
    {
        public string StudentId { get; set; }
        public string RecruiterId { get; set; }
        public bool IsRecruiter { get; set; }
        public Student Student { get; set; }
        public Recruiter Recruiter { get; set; }
    }
}
