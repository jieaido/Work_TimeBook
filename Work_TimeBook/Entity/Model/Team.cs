using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class TeamEntity
    {
        public TeamEntity ()
        {
            //StationEntity=new HashSet<StationEntity>();
            UserInfos=new HashSet<UserInfoEntity>();
            AdminUserinfos=new List<UserInfoEntity>();
        }
        public int TeamEntityId { get; set; }
        public string   TeamName { get; set; }

        public virtual ICollection<StationEntity> StationEntity { get; set; }
        public virtual ICollection<UserInfoEntity> UserInfos { get; set; }
        public virtual ICollection<UserInfoEntity> AdminUserinfos { get; set; }
    }
    }

