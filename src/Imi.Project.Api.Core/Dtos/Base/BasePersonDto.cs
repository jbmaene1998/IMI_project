using System;
using System.ComponentModel.DataAnnotations;
using Imi.Project.Api.Core.Attributes;

namespace Imi.Project.Api.Core.Dtos.Base
{
    public class BasePersonDto : DtoBase
    {
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name has to be between 2 and 20 characters.")]
        public string LastName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name has to be between 2 and 20 characters.")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [CheckDateAttribute(ErrorMessage = "Date is invalid. Can't be higher then current date.")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone is invalid")]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //Data annotation will be added later
        public string ImageUrl { get; set; }
        [Required]
        [RegularExpression(@"[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}", ErrorMessage = "The given Id of data type Guid is invalid.")]
        public string LocationId { get; set; }
    }
}
