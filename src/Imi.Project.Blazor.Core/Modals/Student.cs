using Imi.Project.Api.Core.Entities;
using Imi.Project.Blazor.CoreModals.Base;
using System;
using System.Collections.Generic;
using System.Text;
namespace Imi.Project.Blazor.Core.Modals
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
        public string SchoolSearchText { get; set; }
        public string CitySearchText { get; set; }
        public string JobSearchText { get; set; }
    }
}
