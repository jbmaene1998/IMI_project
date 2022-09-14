using System;
using System.Collections.Generic;
using System.Text;
using Imi.Project.Api.Core.Dtos.Base;

namespace Imi.Project.Api.Core.Dtos
{
    public class VacancyResponseDto : DtoBase
    {
        public string Name { get; set; }
        public string RecruiterId { get; set; }
        public string JobId { get; set; }
    }
}
