using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class TeamEntity
    {
        public int TeamEntityId { get; set; }
        public string   TeamName { get; set; }

        public virtual ICollection<UserInfoEntity> UserInfos { get; set; }
    }
}
