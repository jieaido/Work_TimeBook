using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

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

    public class RegisterViewModel
    {
        [Required]
        [Remote("ValiteUserName","Login",ErrorMessage = "用户名已存在")]
        [Display(Name ="用户名")]
        public string UserName { get; set; }
       [Required]
       [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "真实姓名")]
        public string RealName { get; set; }
        [Display(Name = "班组")]
        public int TeamId { get; set; }
        
    }
}