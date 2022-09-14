using System.ComponentModel.DataAnnotations;
using Imi.Project.Api.Core.Dtos.Base;

namespace Imi.Project.Api.Core.Dtos
{
    public class LocationRequestDto : DtoBase
    {
        public string Continent { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Population { get; set; }
    }
}
