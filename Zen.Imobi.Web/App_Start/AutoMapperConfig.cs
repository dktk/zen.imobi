using AutoMapper;
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
            CreateMapping<PropertyDao, CreatePropertyModel>();
            CreateMapping<PropertyDao, RentPropertyModel>();

            CreateMapping<Location, LocationDao>();
            CreateMapping<CreatePropertyModel, Location>();
        }

        private static void CreateMapping<TSource, TDestionation>()
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestionation);

            Mapper.CreateMap<TSource, TDestionation>();
            Mapper.CreateMap<TDestionation, TSource>();
        }
    }
}