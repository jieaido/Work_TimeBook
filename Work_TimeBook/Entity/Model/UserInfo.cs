using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public class UserInfo
    {
        /// <summary>
        ///     用户ID
        /// </summary>
        public int UserInfoId { get; set; }

        /// <summary>
        ///     登录名
        /// </summary>
        [Required]
        public string LoginName { get; set; }

        /// <summary>
        ///     登陆密码
        /// </summary>
        [Required]
        public string LoginPwd { get; set; }

        /// <summary>
        ///     真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        public string Description { get; set; }

        public virtual  IEnumerable<Role> Roles { get; set; }
         

        public virtual Team Team { get; set; }
    }
}