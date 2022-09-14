using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Imi.Project.Api.Core.Entities.BaseEntities;

namespace Imi.Project.Api.Core.Dtos
{
    public class SchoolRequestDto : BaseBuilding
    {
        [Required]
        [RegularExpression(@"[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "The given Id of data type Guid is invalid.")]
        public string LocationId { get; set; }
    }
}
