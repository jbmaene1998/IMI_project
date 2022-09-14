using Imi.Project.Api.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Entities
{
    public class Job : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Vacancy> Vacancies { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
