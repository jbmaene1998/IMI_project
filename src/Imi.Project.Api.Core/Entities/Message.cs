using Imi.Project.Api.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{
    public class Message : BaseEntity
    {
        public string FromId { get; set; }
        public string ToId { get; set; }
        public Student Student { get; set; }
        public Recruiter Recruiter { get; set; }
        public string TextMessage { get; set; }
        public DateTime DateTimeMessage { get; set; }
    }
}
