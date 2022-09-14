using Imi.Project.Api.Core.Entities.BaseEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{ 
    public class Student : BasePerson
    {
        public string JobId { get; set; }
        public string SchoolId { get; set; }
        public ICollection<Match> Matches { get; set; }
        public Job Job { get; set; }
        public School School { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
