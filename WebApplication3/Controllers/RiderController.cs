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
using WebApp.Core.Models;

using Dapper;

namespace WebApplication3.Controllers
{
    public class RiderController : Controller
    {
        /*
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        */

        private IConfiguration _config;

        public RiderController(IConfiguration config)
        {
            _config = config;
        }




        public IActionResult Index()
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query("select * from Riders");

                return View(data);
            }
        }

        //CREATE IMPLEMENTATION

        [HttpPost]
        public IActionResult Create(Rider riders)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query<Rider>(@"
insert into Riders(RiderName, RiderRating, RiderPhone)
values (@RiderName, @RiderRating, @RiderPhone);

select * from Riders where Id = @Id;
", riders).FirstOrDefault();

                return View(data);
            }
        }

        public IActionResult Create(int id)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query("select * from Riders where Id = @id", new { id }).FirstOrDefault();

                return View(data);
            }

        }





        //UPDATE IMPLEMENTATION

        [HttpPost]
        public IActionResult Edit(Rider riders)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query<Rider>(@"
update Riders
set RiderName = @RiderName, RiderRating = @RiderRating, RiderPhone = @RiderPhone
where Id = @Id;
select * from Riders where Id = @Id;
", riders).FirstOrDefault();

                return View(data);
            }
        }

        public IActionResult Edit(int? id)
        {

            if (id.HasValue)
            {
                using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
                {
                    var data = db.Query("select * from Riders where Id = @id", new { id }).FirstOrDefault();

                    return View(data);
                }
            }

            Rider emptyRider = new Rider();

            return View(emptyRider);

        }


        [HttpPost]
        public IActionResult Delete(Rider riders)
        {
            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query<Rider>(@"

update Riders
set RiderName = @RiderName, RiderRating = @RiderRating, RiderPhone = @RiderPhone
where Id = @Id;
select * from Riders where Id = @Id;
", riders).FirstOrDefault();

                return View(data);
            }
        }

        public IActionResult Delete(int id)
        {

            using (var db = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]))
            {
                var data = db.Query("select * from Riders where Id = @id", new { id }).FirstOrDefault();

                return View(data);
            }

        }

    }
}
