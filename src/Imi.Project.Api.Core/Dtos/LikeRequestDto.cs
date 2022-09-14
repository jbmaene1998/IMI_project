using Imi.Project.Api.Core.Dtos.Base;
using System;
using System.ComponentModel.DataAnnotations;


namespace Imi.Project.Api.Core.Dtos
{
    public class LikeRequestDto : DtoBase
    {
        [Required]
        [RegularExpression(@"[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "The given Id of data type Guid is invalid.")]
        public string StudentId { get; set; }
        [Required]
        [RegularExpression(@"[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "The given Id of data type Guid is invalid.")]
        public string RecruiterId { get; set; }
        [Required]
        public bool IsRecruiter { get; set; }
    }
}
