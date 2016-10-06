using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class UserInfoEditViewModel
    {
        public int UserInfoEntityId { get; set; }

       

        /// <summary>
        ///     真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public string Description { get; set; }
        
    }

    public class UserinfoChangePwdViewModel
    {
        [Key]
        public int UserInfoEntityId { get; set; }


        public string OldPwd { get; set; }
        public string LoginPwd { get; set; }

        [Compare("LoginPwd")]
        public string CofirmPwd { get; set; }
    }
}