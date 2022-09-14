using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Imi.Project.Api.Core.Dtos.Base;

namespace Imi.Project.Api.Core.Dtos
{
    public class VacancyRequestDto : DtoBase
    {
        [Required]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Name has to be between 10 and 20 characters.")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "The given Id of data type Guid is invalid.")]
        public string RecruiterId { get; set; }
        [Required]
        [RegularExpression(@"[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "The given Id of data type Guid is invalid.")]
        public string JobId { get; set; }
    }
}
