using Imi.Project.Mobile.Core.Modals.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Modals
{
    public class School : BaseBuilding
    {
        public ICollection<Student> Students { get; set; }
        public Location Location { get; set; }
        public string LocationId { get; set; }
        
    }
}
