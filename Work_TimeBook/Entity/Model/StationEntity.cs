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
        public StationEntity()
        {
            this.WorkTimeEntities = new HashSet<WorkTimeEntity>();
        }
        [Key]
        public int StationId { get; set; }
        public string StationName { get; set; }
        public string Derscpion { get; set; }

        public virtual TeamEntity TeamEntities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkTimeEntity> WorkTimeEntities { get; set; }


    }
}
