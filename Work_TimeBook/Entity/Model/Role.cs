using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Role
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }
        
        public virtual  IEnumerable<Permiss> Permisses { get; set; }

    }
}
