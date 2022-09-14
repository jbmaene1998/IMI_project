using Imi.Project.Api.Core.Dtos;
using Imi.Project.Blazor.CoreModals.Base;
using Imi.Project.Mobile.Core.Modals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Modals
{
    public class Recruiter : BasePerson
    {
        public string CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Match> Matches { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Like> Likes { get; set; }
        public string CompanySearchText { get; set; }
        public string CitySearchText { get; set; }
    }
}
