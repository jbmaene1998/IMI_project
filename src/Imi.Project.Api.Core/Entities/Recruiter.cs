using Imi.Project.Api.Core.Entities.BaseEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
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
