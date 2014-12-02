using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PropertyLogic.Data;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations.Infrastructure;

namespace Zen.Imobi.Web
{
    public class DataMigrationInitializer : IDatabaseInitializer<PropertyContext>
    {
        public void InitializeDatabase(PropertyContext context)
        {
            if (!context.Database.Exists() || !context.Database.CompatibleWithModel(false))
            {
                var configuration = new DbMigrationsConfiguration();
                var migrator = new DbMigrator(configuration);
                migrator.Configuration.TargetDatabase = new DbConnectionInfo(context.Database.Connection.ConnectionString, "System.Data.SqlClient");
                var migrations = migrator.GetPendingMigrations();
                if (migrations.Any())
                {
                    var scriptor = new MigratorScriptingDecorator(migrator);
                    string script = scriptor.ScriptUpdate(null, migrations.Last());
                    if (!String.IsNullOrEmpty(script))
                    {
                        context.Database.ExecuteSqlCommand(script);
                    }
                }
            }
        }
    }
}