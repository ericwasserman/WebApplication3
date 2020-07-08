using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using WebApp.Service.Interfaces;
using WebApp.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {

        private IConfiguration _config;
        private IDriverService _driverService;
        public DriversController(IConfiguration config, IDriverService driverService)
        {
            _config = config;
            _driverService = driverService;
        }


        // GET: api/drivers
        [HttpGet]
        public async Task<IEnumerable<Driver>> Get()
        {
            var drivers = await _driverService.GetAll();

            return drivers;
        }

        // GET api/drivers/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Driver>> Get(int id)
        {
            var drivers = await _driverService.GetDriver(id);

            return drivers;

        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task Post(Driver driver)
        {
            driver.UberId = Guid.NewGuid();
            await _driverService.Insert(driver);
            
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task Put(Driver driver)
        {
            driver.UberId = Guid.NewGuid();
            await _driverService.Edit(driver);

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _driverService.Delete(id);
        
        }
    }
}
