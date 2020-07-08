﻿using System;
using System.Linq;

using DbUp.Engine;

namespace WebApp.Database
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                args.FirstOrDefault() ??
                "Server=localhost; Database=Uber; Trusted_Connection=True";
            DatabaseUpgradeResult result = Deployer.DeployDatabase(connectionString);

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
        }
    }
}
