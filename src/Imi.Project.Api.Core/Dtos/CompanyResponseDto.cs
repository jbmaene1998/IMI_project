using Imi.Project.Api.Core.Dtos.Base;
using Newtonsoft.Json;

namespace Imi.Project.Api.Core.Dtos
{
    public class CompanyResponseDto : BaseBuildingDto
    {
        public LocationResponseDto Location { get; set; }
    }
}
