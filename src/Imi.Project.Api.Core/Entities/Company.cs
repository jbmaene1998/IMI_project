using Imi.Project.Api.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{
    public class Company : BaseBuilding
    {
        public ICollection<Recruiter> Recruiters { get; set; }
        public string LocationId { get; set; }
        public Location Location { get; set; }
    }
}
