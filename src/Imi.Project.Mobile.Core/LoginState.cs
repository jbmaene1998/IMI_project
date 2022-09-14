using Imi.Project.Mobile.Core.Modals.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core
{
    public static class LoginState
    {
        public static string Token { get; set; }
        public static string Id{ get; set; }
        public static bool IsRecruiter{ get; set; }
        public static event Action OnSet;
        public static void SetToken(string token)
        {
            Token = token;
            NotifyStateChanged();
        }
        public static void SetId(string id)
        {
            Id = id;
            NotifyStateChanged();
        }
        public static void SetIsRecruiter(bool input)
        {
            IsRecruiter = input;
            NotifyStateChanged();
        }
        public static void Logout()
        {
            Token = null;
            Id = null;
            IsRecruiter = false;
        }
        private static void NotifyStateChanged() => OnSet?.Invoke();

    }
}
