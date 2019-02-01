using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Liberry.Web.Models
{
    public class LoginModel
    {
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string RedirectURL { get; set; }
    }
}