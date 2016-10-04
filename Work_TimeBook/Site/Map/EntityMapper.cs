﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Entity.Model;
using Site.Models;

namespace Site.Map
{
    public  static class EntityMapper
    {
        public static  void RegEntityMapper(IMapperConfigurationExpression cfg)
        {
           cfg.CreateMap<StationEntity, StationViewModel>();
            cfg.CreateMap<StationViewModel, StationEntity>();

            //var config = new MapperConfiguration(cfg => cfg.CreateMap<StationEntity, StationViewModel>());

        }

        public static StationEntity GetStationEntityByViewModel(StationViewModel model)
        {
            return Mapper.Map<StationEntity>(model);
        }public static StationViewModel GetStationViewModelByEntity(StationEntity model)
        {
           
            return Mapper.Map<StationViewModel>(model);
        }
    }
}