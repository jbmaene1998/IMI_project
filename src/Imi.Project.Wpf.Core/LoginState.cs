
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Wpf.Core
{
    static class LoginState
    {
        public static string Token { get; set; }
        public static event Action OnSet;
        public static void SetToken(string token)
        {
            Token = token;
            NotifyStateChanged();
        }
        private static void NotifyStateChanged() => OnSet?.Invoke();

    }
}
