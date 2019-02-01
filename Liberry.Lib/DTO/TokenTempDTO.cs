using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberry.Lib.DTO
{
    public class TokenTempDTO
    {
        [Display(Name = "ID")]
        public int TokenId { get; set; }

        [Display(Name = "Token")]
        public string TokenValue { get; set; }

        [Display(Name = "IP Address")]
        public string IpAddress { get; set; }

        [Display(Name = "Expires")]
        public DateTime Expires { get; set; }

        [Display(Name = "Is Expired?")]
        public bool Expired => Expires <= DateTime.Now;
    }
}
