using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mangau.Demos.StockChat.Web.Models
{
    public class ChatMessage
    {
        public long Id { get; set; }

        public DateTime PostedOn { get; set; }

        public string PostedBy { get; set; }

        public string Message { get; set; }
    }
}
