using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using WebApp.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RidersController : ControllerBase
    {

        private IConfiguration _config;
        public RidersController(IConfiguration config)
        {
            _config = config;
        }

        // GET: api/riders
        [HttpGet]
        public IEnumerable<Rider> Get()
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query<Rider>("select * from Riders");
                return data;
            }
        }

        // GET api/riders/5
        [HttpGet("{id}")]
        public Rider Get(int id)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query<Rider>("select * from Riders where Id = @id", new { id }).FirstOrDefault();
                return data;
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(Rider riders)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                riders.RiderUberId = Guid.NewGuid();
                var data = db.Query(@"
insert into Riders(RiderName, RiderRating, RiderPhone)
values (@RiderName, @RiderRating, @RiderPhone);

select * from Riders where RiderUberId = @RiderUberId;
", riders).FirstOrDefault();

            }
            
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(Rider riders)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query<Rider>(@"
update Riders
set RiderName = @RiderName, RiderRating = @RiderRating, RiderPhone = @RiderPhone
where Id = @id;
select * from Riders where Id = @id;
", riders).FirstOrDefault();
            }
            

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {   
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query<int>(@"

update Drivers
set  isActive = 0
where Id = @id;
", new { id }).FirstOrDefault();

            }
            
            
        }
    }
}
