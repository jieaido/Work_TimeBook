using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity.Model;

namespace Site.Models
{
    public class StationViewModel
    {
        public int StationId { get; set; }
        public string StationName { get; set; }
        public string Derscpion { get; set; }

        public int TeamEntityId  { get; set; }
        
    }
}