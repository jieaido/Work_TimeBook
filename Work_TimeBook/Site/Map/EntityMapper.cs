using AutoMapper;
using Entity.Model;
using Site.Models;

namespace Site.Map
{
    public static class EntityMapper
    {
        public static void RegEntityMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<StationEntity, StationViewModel>();
            cfg.CreateMap<StationViewModel, StationEntity>();
            cfg.CreateMap<WorkTimeEntity, WorkTimeViewModel>();
            cfg.CreateMap<WorkTimeViewModel, WorkTimeEntity>();
            cfg.CreateMap<UserInfoEntity, UserInfoEditViewModel>();
            cfg.CreateMap<UserInfoEditViewModel, UserInfoEntity>();
            cfg.CreateMap<UserinfoChangePwdViewModel, UserInfoEntity>();
            cfg.CreateMap<UserInfoEntity, UserinfoChangePwdViewModel>();

            //var config = new MapperConfiguration(cfg => cfg.CreateMap<StationEntity, StationViewModel>());
        }

        public static StationEntity GetStationEntityByViewModel(StationViewModel model)
        {
            return Mapper.Map<StationEntity>(model);
        }

        public static StationViewModel GetStationViewModelByEntity(StationEntity model)
        {
            return Mapper.Map<StationViewModel>(model);
        }
        /// <summary>
        /// 从源中获得一个映射实体
        /// </summary>
        /// <typeparam name="T">要生成的实体类型</typeparam>
        /// <typeparam name="TKey">源的类型</typeparam>
        /// <param name="source">源</param>
        /// <returns></returns>
        public static T GetEntity<T,TKey>(TKey source)
        {
            return Mapper.Map<T>(source);
        }
    }
}