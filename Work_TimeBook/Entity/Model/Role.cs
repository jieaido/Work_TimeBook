using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class RoleEntity
    {
        public RoleEntity()
        {
            Permisses=new HashSet<PermissEntity>();
            UserInfoEntities=new HashSet<UserInfoEntity>();
        }
        public int RoleEntityId { get; set; }

        public string RoleName { get; set; }
        
        public virtual  ICollection<PermissEntity> Permisses { get; set; }
        public virtual ICollection<UserInfoEntity> UserInfoEntities { get; set; } 

    }
}
