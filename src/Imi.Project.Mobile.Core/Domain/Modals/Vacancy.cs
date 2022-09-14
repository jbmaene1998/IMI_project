using Imi.Project.Mobile.Core.Modals.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Modals
{
    public class Vacancy : BaseEntity 
    {
        public string Name { get; set; }
        public string RecruiterId { get; set; }
        public Recruiter Recruiter { get; set; }
        public string JobId { get; set; }
        public Job Job { get; set; }
        
    }
}
