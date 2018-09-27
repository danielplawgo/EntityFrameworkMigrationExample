using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using EFMigrationExample.DataAccess;
using EFMigrationExample.DataAccess.Migrations;

namespace EFMigrationExample.Migrator
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<Options>(args);

            result
                .WithParsed(r => Migrate(r));
        }

        private static void Migrate(Options options)
        {
            var configuration = new Configuration();

            configuration.TargetDatabase = new DbConnectionInfo(
                options.ConnectionString,
                "System.Data.SqlClient");

            var migrator = new DbMigrator(configuration);
            //migrator.Update();

            MigratorLoggingDecorator logger = new MigratorLoggingDecorator(migrator, new MigrationLogger());
            logger.Update();
        }
    }
}
