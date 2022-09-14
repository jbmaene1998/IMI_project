using System;
using System.ComponentModel.DataAnnotations;
using Imi.Project.Api.Core.Attributes;
using Imi.Project.Api.Core.Dtos.Base;

namespace Imi.Project.Api.Core.Dtos
{
    public class MessageRequestDto : DtoBase
    {
        [Required]
        [RegularExpression(@"[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "The given Id of data type Guid is invalid.")]
        public string FromId { get; set; }
        [Required]
        [RegularExpression(@"[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "The given Id of data type Guid is invalid.")]
        public string ToId { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Street has to be between 1 and 150 characters.")]
        public string TextMessage { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [CheckDate(ErrorMessage = "Date is invalid. Can't be higher then current date.")]
        public DateTime DateTimeMessage { get; set; }
    }
}
