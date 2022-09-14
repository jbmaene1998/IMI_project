
using Imi.Project.Blazor.CoreModals.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Modals
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
