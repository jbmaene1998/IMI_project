using Imi.Project.Blazor.CoreModals.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Modals
{
    public class Match : BaseEntity
    {
        public string StudentId { get; set; }
        public string RecruiterId { get; set; }
        public DateTime CreateDate { get; set; }
        public Recruiter Recruiter { get; set; }
        public Student Student { get; set; }
    }
}
