using Imi.Project.Api.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{
    public class School : BaseBuilding
    {
        public ICollection<Student> Students { get; set; }
        public Location Location { get; set; }
        public string LocationId { get; set; }
        
    }
}
