using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class MenuEntity
    {
        public int MenuEntityId { get; set; }
        public int ParentMenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuDisplayName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        public int  SortId { get; set; }    
    }
}
