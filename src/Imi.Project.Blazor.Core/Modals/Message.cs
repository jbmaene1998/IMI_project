using Imi.Project.Blazor.Core.Modals;
using Imi.Project.Blazor.CoreModals.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Modals
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
