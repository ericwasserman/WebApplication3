using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

using Microsoft.Extensions.Configuration;

using WebApp.Core.Models;
using WebApp.Data.Repositories.Interfaces;
using WebApp.Data.SQL;

using Dapper;

// execute means no data expected coming back vs query 

namespace WebApp.Data.Repositories
{
    public class DriverRepository : IDriverRepository
    {

        private IConfiguration _config;

        public DriverRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<Driver>> GetAll()
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                var data = await db.QueryAsync<Driver>(DriverQueries.GetAll);

                return data;
            }
        }

        public async Task Create(Driver driver)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                try
                {
                    await db.ExecuteAsync(DriverQueries.Create, driver);

                }
                catch(Exception e)
                {
                    throw new Exception("Could not create Driver with following parameters - Name:" + driver.DriverName + "Phone" + driver.DriverPhone + "Rating" + driver.DriverRating, e);
                }
            }
        }

        public async Task Delete(int id)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                try
                {
                    await db.QueryAsync(DriverQueries.Delete, new { id });
                }
                catch (Exception e)
                {
                    throw new Exception("Could not create Driver with following Id" + id, e);
                }
            }
        }

        public async Task Edit(Driver driver)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                try
                {

                    Debug.Print("Testing Debug");
                    await db.QueryAsync(DriverQueries.Edit, driver);

                }
                catch (Exception e)
                {
                    Debug.Print("Error editing driver");
                    throw new Exception("Could not create Driver with following parameters - Name:" + driver.DriverName + "Phone" + driver.DriverPhone + "Rating" + driver.DriverRating, e);
                }

            }
        }

        public async Task<IEnumerable<Driver>> GetDriver(int id)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                var data = await db.QueryAsync<Driver>(DriverQueries.GetDriver, new { id });
                return data;
            }
        }
    }
}
