using Base.Data;
using System;
using System.Data.SqlClient;

namespace PropertyLogic.Data
{
    public class PropertiesRepository : Repository<PropertyContext, PropertyDao>, IPropertiesRepository
    {
        public PropertiesRepository() { }

        public int ChangePropertyRentStatus(Guid propertyId, Guid userId, PropertyStatus propertyStatus)
        {
            // todo: based on the bussiness conditions, this could throw if the user does not own the property
            // should we catch this???
            // maybe should catch the SQL exception with code 10000001 only ???
            return ExecuteQuery("sp_ChangePropertyRentStatus",
                new[] {  
                    new SqlParameter("@propertyId", propertyId),
                    new SqlParameter("@userId", userId),
                    new SqlParameter("@status", (int)propertyStatus)
                });
        }
    }
}