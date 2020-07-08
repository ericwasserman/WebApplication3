using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using WebApp.Service.Interfaces;
using WebApp.Core.Models;

using Dapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RidersController : ControllerBase
    {

        private IConfiguration _config;
        private IRiderService _riderService;
        public RidersController(IConfiguration config, IRiderService riderService)
        {
            _config = config;
            _riderService = riderService;
        }


        // GET: api/Riders
        [HttpGet]
        public async Task<IEnumerable<Rider>> Get()
        {
            var riders = await _riderService.GetAll();

            return riders;
        }

        // GET api/riders/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Rider>> Get(int id)
        {
            var riders = await _riderService.GetRider(id);

            return riders;

        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task Post(Rider rider)
        {
            rider.RiderUberId = Guid.NewGuid();
            await _riderService.Create(rider);
            
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task Put(Rider rider)
        {
            rider.RiderUberId = Guid.NewGuid();
            await _riderService.Edit(rider);

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _riderService.Delete(id);
        
        }
    }
}
