using Imi.Project.Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Wpf.Core.Interfaces
{
    public interface IUserService
    {
        Task<string> Login(string email, string password);
    }
}
