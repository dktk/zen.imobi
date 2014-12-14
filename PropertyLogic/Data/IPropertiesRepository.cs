using Base.Data;
using Base.Domain;
using System;

namespace PropertyLogic.Data
{
    public interface IPropertiesRepository : IRepository<PropertyDao>
    {
        int RentProperty(Guid propertyId, Guid userId);
    }
}