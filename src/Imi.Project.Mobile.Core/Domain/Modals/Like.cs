using Imi.Project.Mobile.Core.Modals.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Modals
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
