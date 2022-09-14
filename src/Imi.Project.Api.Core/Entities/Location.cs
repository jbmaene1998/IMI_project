using System;
using System.Collections.Generic;
using System.Text;
using Imi.Project.Api.Core.Entities.BaseEntities;

namespace Imi.Project.Api.Core.Entities
{
    public class Location : BaseEntity
    {
        public string Continent { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Population { get; set; }
        public IEnumerable<School> Schools { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Recruiter> Recruiters { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
