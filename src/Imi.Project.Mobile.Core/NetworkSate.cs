using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Imi.Project.Mobile.Core
{
    public static class NetworkSate
    {
        public static string IP { get ; set; } 
        public static event Action OnSet;
        public static string GetIP()
        {
            return "http://192.168.1.100:5000/";
        }
    }
}
