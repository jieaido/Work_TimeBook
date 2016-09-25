using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class MenubarViewModel
    {
        public int MenuId { get; set; } 
        public string MenusName { get; set; }
        public int ParentId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        
    }
}