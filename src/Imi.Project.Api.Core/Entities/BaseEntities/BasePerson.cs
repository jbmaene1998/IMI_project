using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Imi.Project.Api.Core.Entities.BaseEntities
{
    public class BasePerson : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImageUrl { get; set; }
        public string LocationId { get; set; }
        public Location Location { get; set; }
        public bool IsRecruiter { get; set; }
        public bool IsAdmin { get; set; }
        public bool HasApprovedTermsAndConditions { get; set; }
    }
}