using System;
using System.Collections.Generic;
using System.Text;
using Imi.Project.Api.Core.Dtos.Base;

namespace Imi.Project.Api.Core.Dtos
{
    public class SchoolResponseDto : BaseBuildingDto
    {
        public LocationResponseDto Location { get; set; }
    }
}
