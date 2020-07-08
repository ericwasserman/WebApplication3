using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using System.Data.SqlClient;

using Microsoft.Extensions.Configuration;

using WebApp.Core.Models;
using WebApp.Data.Repositories.Interfaces;
using WebApp.Data.SQL;

using Dapper;

namespace WebApp.Data.Repositories
{
    public class RiderRepository : IRiderRepository
    {

        private IConfiguration _config;

        public RiderRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<Rider>> GetAll()
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                var data = await db.QueryAsync<Rider>(RiderQueries.GetAll);

                return data;
            }
        }

        public async Task Create(Rider rider)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                try
                {
                    await db.ExecuteAsync(RiderQueries.Create, rider);

                }
                catch (Exception e)
                {
                    Debug.Print("Error creating Rider");
                    throw new Exception("Could not create Rider with following parameters - Name:" + rider.RiderName + "Phone" + rider.RiderPhone + "Rating" + rider.RiderRating, e);
                }
            }
        }

        public async Task Delete(int id)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                try
                {
                    await db.QueryAsync(RiderQueries.Delete, new { id });
                }
                catch (Exception e)
                {
                    throw new Exception("Could not create Rider with following Id" + id, e);
                }
            }
        }

        public async Task Edit(Rider rider)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                await db.QueryAsync(RiderQueries.Edit, rider);
            }
        }

        public async Task<IEnumerable<Rider>> GetRider(int id)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                var data = await db.QueryAsync<Rider>(RiderQueries.GetRider, new { id });
                return data;
            }
        }
    }
}
