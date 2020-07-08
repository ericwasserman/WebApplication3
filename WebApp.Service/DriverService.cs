using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using WebApp.Core.Models;
using WebApp.Service.Interfaces;
using WebApp.Data.Repositories.Interfaces;

using Dapper;

namespace WebApp.Service
{
    public class DriverService : IDriverService
    {
        private IDriverRepository _driverRepo;

        public DriverService(IDriverRepository driverRepo)
        {
            _driverRepo = driverRepo;
        }
        public async Task<IEnumerable<Driver>> GetAll()
        {
            return await _driverRepo.GetAll();
        }

        public async Task Create(Driver driver)
        {
            //TODO: Business Logic goes here 
            if(driver.Id < 0)
            {
                throw new Exception("Driver is not Valid!");
            }

            await _driverRepo.Create(driver);
        }

        public async Task Delete(int id)
        {
            //TODO: Business Logic goes here 
            if (id == null)
            {
                throw new Exception("Driver is NULL!");
            }

            await _driverRepo.Delete(id);
        }

        public async Task Edit(Driver driver)
        {
            //TODO: Business Logic goes here 
            if (driver.DriverName == null)
            {
                throw new Exception("Driver is NULL!");
            }

            await _driverRepo.Edit(driver);
        }

        public async Task<IEnumerable<Driver>> GetDriver(int id)
        {
            return await _driverRepo.GetDriver(id);
        }
    }
}
