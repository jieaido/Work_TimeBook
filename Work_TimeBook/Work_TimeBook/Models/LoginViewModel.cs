using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Work_TimeBook.Models
{
    public class MyLoginViewModel
    {
        [Required]
        [Display(Name = "登录名")]
        public string LoginName { get; set; }
        [Required]
        [Display(Name = "密码")]
        public string LoginPwd { get; set; }
     
        [Display(Name = "记住我")]
        public bool RememberMe { get; set; }

    }
}