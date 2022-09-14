using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities.BaseEntities
{
    public class BaseBuilding : BaseEntity
    {
        public string Name { get; set; }
        public int PostCode { get; set; }
        public string Street { get; set; }
        public string WebsiteUrl { get; set; }
    }
}
