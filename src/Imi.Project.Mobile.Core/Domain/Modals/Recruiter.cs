using Imi.Project.Mobile.Core.Modals.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Modals
{
    public class Recruiter : BasePerson
    {
        public string CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Match> Matches { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Like> Likes { get; set; }

    }
}
