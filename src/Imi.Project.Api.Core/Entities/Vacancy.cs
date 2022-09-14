using Imi.Project.Api.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
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
