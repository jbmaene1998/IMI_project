using Imi.Project.Mobile.Core.Modals.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Modals
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
