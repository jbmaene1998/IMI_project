using Imi.Project.Mobile.Core.Modals.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Imi.Project.Mobile.Core.Modals
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
        public string LocationName { get; set; }
        public string JobName { get; set; }
        public string SchoolName { get; set; }
    }
}
