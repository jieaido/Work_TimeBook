using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class FunctionEntity
    {
        [Key]
        public int  FuntionEntityId { get; set; }
        public string FuntionName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

    }
}
