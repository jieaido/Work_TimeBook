using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class LoginViewModel
    {
        public string LoginName     { get; set; }
        public string LoginPwd { get; set; }
        public bool RememberMe { get; set; }
    }
}