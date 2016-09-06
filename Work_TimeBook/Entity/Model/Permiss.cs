using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
   public class Permiss
    {
       public int PermissId { get; set; }
       public string PermissName { get; set; }
        public string ControllerName { get; set; }
       public string ActionName { get; set; }

        public virtual IEnumerable<Role> Roles { get; set; } 
    }
}
