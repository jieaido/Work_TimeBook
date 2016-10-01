using System.Collections.Generic;
using System.Linq;
using Entity.Model;

namespace Entity.InterFace
{
    public interface IStationEntityRepos:IBaseRepos<StationEntity>
    {
        IEnumerable<TeamEntity> GetAllTeams();
    }
    public class  StationEntityRepos:BaseRepos<StationEntity>,IStationEntityRepos
    {
        public StationEntityRepos(EFDbContext context) : base(context)
        {
        }

        public IEnumerable<TeamEntity> GetAllTeams()
        {
           return  GetContext().Teams.ToList();
        }
    }
}