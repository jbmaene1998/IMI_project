using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Core.Interfaces
{
{
    public interface IApiUserService
    {
        Task<string> Login(string email, string password);
    }
}
