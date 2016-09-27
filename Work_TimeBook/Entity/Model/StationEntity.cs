using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class StationEntity
    {
        [Key]
        public int StationId { get; set; }
        public String StationName { get; set; }
        public string Derscpion { get; set; }
        public virtual TeamEntity TeamEntity { get; set; }

    }
}
