using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core
{
    public static class NetworkSate
    {
        public static string IP { get; set; }
        public static event Action OnSet;
        public static string GetIP()
        {
            return "https://localhost:5001/";
        }
    }
}
