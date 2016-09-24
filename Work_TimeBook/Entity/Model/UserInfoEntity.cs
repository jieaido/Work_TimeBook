using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public class UserInfoEntity
    {
        public UserInfoEntity()
        {
            Roles=new HashSet<RoleEntity>();
        }
        /// <summary>
        ///     用户ID
        /// </summary>
        public int UserInfoEntityId { get; set; }

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

        public virtual  ICollection<RoleEntity> Roles { get; set; }
         

        public virtual TeamEntity Team { get; set; }
    }
}