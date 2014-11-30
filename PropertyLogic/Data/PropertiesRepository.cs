using Base.Data;
using System;

namespace PropertyLogic.Data
{
    public class PropertiesRepository : Repository<PropertyContext, PropertyDao>, IPropertiesRepository
    {
        public PropertiesRepository() { }
    }
}