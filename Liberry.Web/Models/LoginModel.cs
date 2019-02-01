using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Liberry.Web.Models
{
    public class LoginModel
    {
        public string Password { get; set; }
        public string RedirectURL { get; set; }
    }
}