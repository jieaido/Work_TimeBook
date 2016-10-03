using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class WorkTimeEntity
    {
        [Key]
        public int WorkTimeId { get; set; }
        public System.DateTime WtStartDateTime { get; set; }
        public System.DateTime WtOverDateTime { get; set; }
        public float WtValue { get; set; }
        public string WtContent { get; set; }
        public string Remarks { get; set; }
        public System.DateTime CreateTime { get; set; }

        public virtual StationEntity StationEntities { get; set; }




    }
}
