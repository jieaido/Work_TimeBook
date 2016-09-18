using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class Menubar
    {
        public int MenuId { get; set; } 
        public string MenusNam { get; set; }
        public int ParentId { get; set; }
        
    }
}