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
        /// <summary>
        /// 迫不得已只能建立的外键列
        /// </summary>
        public int TeamEntityId { get; set; }
        public virtual TeamEntity TeamEntity { get; set; }
        public virtual ICollection<WorkTimeEntity> WorkTimeEntities { get; set; } 
        

    }
}
