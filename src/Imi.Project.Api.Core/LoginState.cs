using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core
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
