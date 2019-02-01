using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberry.Lib.DTO
{
    public class TokenResponse
    {
        public bool Valid { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
