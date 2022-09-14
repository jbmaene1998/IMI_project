using Imi.Project.Mobile.Core.Modals.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Domain.Interfaces
{
    public interface IUserService
    {
        Task<BasePerson> Validate(string email, string password);
    }
}
