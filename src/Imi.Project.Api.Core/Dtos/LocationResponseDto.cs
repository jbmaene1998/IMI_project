using Imi.Project.Api.Core.Dtos.Base;

namespace Imi.Project.Api.Core.Dtos
{
    public class LocationResponseDto : DtoBase
    {
        public string Continent { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Population { get; set; }
        public string Output { get; set; }
    }
}
