﻿using AutoMapper;
using PropertyLogic;
using PropertyLogic.Data;
using Zen.Imobi.Models.Property;

namespace Zen.Imobi.Web
{
    public class AutoMapperConfig
    {
        public static void Start()
        {
            CreateMapping<CreatePropertyModel, Property>();
            CreateMapping<CreatePropertyModel, Location>();
        }

        private static void CreateMapping<TSource, TDestionation>()
        {
            Mapper.CreateMap<TSource, TDestionation>();
            Mapper.CreateMap<TDestionation, TSource>();
        }
    }
}