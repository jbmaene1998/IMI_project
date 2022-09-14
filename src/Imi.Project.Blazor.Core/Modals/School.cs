using Imi.Project.Blazor.CoreModals.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Modals
{
    public class School : BaseBuilding
    {
        public ICollection<Student> Students { get; set; }
        public Location Location { get; set; }
        public string LocationId { get; set; }
        
    }
}
