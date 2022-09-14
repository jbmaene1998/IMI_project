using System.ComponentModel.DataAnnotations;
using Imi.Project.Api.Core.Dtos.Base;

namespace Imi.Project.Api.Core.Dtos
{
    public class JobRequestDto : DtoBase
    {
        [Required]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Name has to be between 10 and 20 characters.")]
        public string Name { get; set; }
    }
}
