using System;
using System.Collections.Generic;
using System.Text;

namespace Mangau.Demos.StockChat.Configuration
{
    public class AppSettings
    {
        public ConnectionStringsSettings ConnectionStrings { get; set; }

        public AuthenticationSettings Authentication { get; set; }

        public int LogoutExpiredInterval { get; set; }

        public int MaxChatMessages { get; set; } = 50;

        public string StockApiBaseAddress { get; set; }
    }
}
