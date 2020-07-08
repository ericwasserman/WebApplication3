using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using WebApp.Core.Models;
using WebApp.Service.Interfaces;
using WebApplication3.Models;

using Dapper;

namespace WebApplication3.Controllers
{
    using WebApp.Database;

    public class HomeController : Controller
    {
        /*
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        */

        private IConfiguration _config;
        private IDriverService _driverService;
        public HomeController(IConfiguration config, IDriverService driverService)
        {
            _config = config;
            _driverService = driverService;
        }

        public async Task<IActionResult> Index()
        {
            var drivers = await _driverService.GetAll();

            return View(drivers); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet] // By Default
        public IActionResult AboutUs()
        {
            AboutUsViewModel vm = new AboutUsViewModel();
            vm.CompanyName = "Uber";
            vm.MissionStatement = "Developer as a Service!";
            vm.StartDate = DateTime.Parse("3/1/2016");

            return View(vm);
        }

        [HttpPost]
        public IActionResult AboutUs(int op1, int op2)
        {
            AboutUsViewModel vm = new AboutUsViewModel();
            vm.Sum = op1 + op2;
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
