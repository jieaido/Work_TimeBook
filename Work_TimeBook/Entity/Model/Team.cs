using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Team
    {
        public int TeamId { get; set; }
        public string   TeamName { get; set; }

        public virtual IEnumerable<UserInfo> UserInfos { get; set; }
    }
}
