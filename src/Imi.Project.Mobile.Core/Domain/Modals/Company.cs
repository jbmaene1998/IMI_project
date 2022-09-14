using Imi.Project.Mobile.Core.Modals.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Modals
{
    public class Company : BaseBuilding
    {
        public ICollection<Recruiter> Recruiters { get; set; }
        public string LocationId { get; set; }
        public Location Location { get; set; }
    }
}
