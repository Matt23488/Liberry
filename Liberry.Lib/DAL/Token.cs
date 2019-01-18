using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberry.Lib.DAL
{
    class Token
    {
        public int TokenId { get; set; }
        public string TokenValue { get; set; }
        public string IpAddress { get; set; }
        public DateTime Expires { get; set; }
    }
}
