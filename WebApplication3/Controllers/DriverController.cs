using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using WebApplication3.Models;
using WebApplication3.Controllers;
using WebApp.Service.Interfaces;
using WebApp.Core.Models;

using Dapper;

namespace WebApplication3.Controllers
{
    public class DriverController : Controller
    {
        private IConfiguration _config;
        private IDriverService _driverService;
        public DriverController(IConfiguration config, IDriverService driverService)
        {
            _config = config;
            _driverService = driverService;
        }

        public async Task<IActionResult> Index()
        {
            var drivers = await _driverService.GetAll();

            return View(drivers);
        }


        //CREATE IMPLEMENTATION


        [HttpPost]
        public async Task Create(Driver drivers)
        {
            drivers.UberId = Guid.NewGuid();
            await _driverService.Create(drivers);
            //            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            //            {
            //                drivers.UberId = Guid.NewGuid();
            //                var data = db.Query<Drivers>(@"
            //insert into Drivers(DriverName, DriverRating, DriverPhone, CompletedRides, UberId, IsActive)
            //values (@DriverName, @DriverRating, @DriverPhone, @CompletedRides, @UberId, 'True');

            //select * from Drivers where UberId = @UberId;
            //", drivers).FirstOrDefault();

            //                return View(data);
            //            }

        }

        public IActionResult Create(int id)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query("select * from Drivers where Id = @id", new { id }).FirstOrDefault();

                return View(data);
            }

        }


        //UPDATE IMPLEMENTATION

        [HttpPost]
        public IActionResult Edit(Driver drivers)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                drivers.UberId = Guid.NewGuid();
                var data = db.Query<Driver>(@"
update Drivers
set DriverName = @DriverName, DriverRating = @DriverRating, DriverPhone = @DriverPhone, CompletedRides = @CompletedRides, UberId = @UberId, IsActive = 'True'
where Id = @Id;
select * from Drivers where UberId = @UberId;
", drivers).FirstOrDefault();

                return View(data);
            }
        }

        public IActionResult Edit(int? id)
        {

            if (id.HasValue)
            {
                using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
                {
                    var data = db.Query("select * from Drivers where Id = @id", new { id }).FirstOrDefault();

                    return View(data);
                }
            }

            Driver emptyDriver = new Driver();

            return View(emptyDriver);

        }


        [HttpPost]
        public IActionResult Delete(Driver drivers)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                drivers.UberId = Guid.NewGuid();
                var data = db.Query<Driver>(@"

update Drivers
set DriverName = @DriverName, DriverRating = @DriverRating, DriverPhone = @DriverPhone, CompletedRides = @CompletedRides, UberId = @UberId, IsActive= 0
where Id = @Id;
select * from Drivers where UberId = @UberId;
", drivers).FirstOrDefault();

                return View(data);
            }
        }

        public IActionResult Delete(int id)
        {

            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query("select * from Drivers where Id = @id", new { id }).FirstOrDefault();

                return View(data);
            }

        }

    }
}
