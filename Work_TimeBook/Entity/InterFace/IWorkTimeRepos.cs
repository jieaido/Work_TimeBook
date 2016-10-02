using System.Collections.Generic;
using Entity.Model;

namespace Entity.InterFace
{
    public interface IWorkTimeRepos:IBaseRepos<WorkTimeEntity>
    {
        IEnumerable<StationEntity> GetAllStation();
        void add(WorkTimeEntity entity);
    }
    public class WorkTimeRepos:BaseRepos<WorkTimeEntity>,IWorkTimeRepos
    {
        private IStationEntityRepos _iStationEntityRepos;

        public WorkTimeRepos(EFDbContext context, IStationEntityRepos iStationEntityRepos) : base(context)
        {
            _iStationEntityRepos = iStationEntityRepos;
        }

        public IEnumerable<StationEntity> GetAllStation()
        {
           return  _iStationEntityRepos.ToList();
        }

        public void add(WorkTimeEntity entity)
        {
            GetSet().Add(entity);
        }
    }
}