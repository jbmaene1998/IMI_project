using System;
using System.Collections.Generic;
using System.Text;
using Imi.Project.Api.Core.Dtos.Base;
using Imi.Project.Api.Core.Entities;

namespace Imi.Project.Api.Core.Dtos
{
    public class StudentResponseDto : Base.BasePersonDto
    {
        public string SchoolId { get; set; }
        public string LocationId { get; set; }
        public string JobId { get; set; }
        public SchoolResponseDto School { get; set; }
        public LocationResponseDto Location { get; set; }
        public JobResponseDto Job { get; set; }
        public string LocationName { get; set; }
        public string JobName { get; set; }
        public string SchoolName { get; set; }
        public string FullName { get; set; }
    }
}
