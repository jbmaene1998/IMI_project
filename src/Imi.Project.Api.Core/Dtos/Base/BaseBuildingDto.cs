using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Dtos.Base
{
    public class BaseBuildingDto : DtoBase
    {
        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name has to be between 3 and 25 characters.")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PostalCode, ErrorMessage = "Post code is invalid.")]
        public int PostCode { get; set; }
        [Required]
        [StringLength(35, MinimumLength = 10, ErrorMessage = "Street has to be between 10 and 35 characters.")]
        public string Street { get; set; }
        [Required]
        [DataType(DataType.Url, ErrorMessage = "Url is invalid")]
        public string WebsiteUrl { get; set; }
        [Required]
        [RegularExpression(@"[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "The given Id of data type Guid is invalid.")]
        public string LocationId { get; set; }
    }
}
