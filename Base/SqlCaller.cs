using System.Collections.Generic;
using System.Data.SqlClient;

namespace Base
{
    // todo: change this name
    public class SqlCaller
    {
        private readonly string _connectionString;

        public SqlCaller(string connectionString)
        {
            Guard.AgainstNullOrEmpty(connectionString);

            _connectionString = connectionString;
        }

        public int ExecuteNonQuery(string storeProcedureName, IEnumerable<SqlParameter> commandParameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.CommandText = storeProcedureName;
                if (command.IsNotNull())
                {
                    foreach (var parameter in commandParameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }

                connection.Open();

                return command.ExecuteNonQuery();
            }
        }
    }
}
