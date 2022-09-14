using System;
using System.Collections.Generic;
using System.Text;
using Imi.Project.Api.Core.Dtos.Base;

namespace Imi.Project.Api.Core.Dtos
{
    public class RecruiterResponseDto : Base.BasePersonDto
    {
        public string CompanyId { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string JobName { get; set; }
        public string SchoolName { get; set; }
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsRecruiter { get; set; }
        public CompanyResponseDto Company { get; set; }
        public LocationResponseDto Location { get; set; }
    }
}
