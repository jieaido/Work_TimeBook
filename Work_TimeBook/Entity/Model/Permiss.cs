using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
   public class PermissEntity
    {
        public int PermissEntityId { get; set; }
        public string PermissName { get; set; }
        public virtual MenuEntity MenuEntity { get; set; }
        public virtual FunctionEntity FunctionEntity { get; set; }
        public virtual IEnumerable<RoleEntity> Roles { get; set; } 
    }
}
