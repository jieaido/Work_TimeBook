using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class RoleEntity
    {
        public int RoleEntityId { get; set; }

        public string RoleName { get; set; }
        
        public virtual  IEnumerable<PermissEntity> Permisses { get; set; }

    }
}
