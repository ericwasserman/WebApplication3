using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using System.Data.SqlClient;

using DbUp;
using DbUp.Engine;
using DbUp.Helpers;
using DbUp.Support;

using Dapper;

namespace WebApp.Database
{
    public static class Deployer
    {
        public static DatabaseUpgradeResult DeployDatabase(string connectionString)
        {
            EnsureDatabase.For.SqlDatabase(connectionString);
            UpgradeEngine upgrader =
                DeployChanges.To
                .SqlDatabase(connectionString)
                .WithTransactionPerScript()
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), (s) => { return s.Contains("Script"); })
                .LogToConsole()
                .Build();
            DatabaseUpgradeResult result = upgrader.PerformUpgrade();
            return result;
        }

        public static DatabaseUpgradeResult DeployTestSeedData(string connectionString)
        {
            EnsureDatabase.For.SqlDatabase(connectionString);
            UpgradeEngine upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithTransactionPerScript()
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), (s) => { return s.Contains("SeedData"); })
                .LogToConsole()
                .Build();

            DatabaseUpgradeResult result = upgrader.PerformUpgrade();
            return result;
        }
    }
}
