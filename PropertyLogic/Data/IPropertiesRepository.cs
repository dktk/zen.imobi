using Base.Data;
using Base.Domain;
using System;

namespace PropertyLogic.Data
{
    public interface IPropertiesRepository : IRepository<PropertyDao>
    {
        int ChangePropertyRentStatus(Guid propertyId, Guid userId, PropertyStatus propertyStatus);
    }
}