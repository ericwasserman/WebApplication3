using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using WebApp.Core.Models;
using WebApp.Service.Interfaces;
using WebApp.Data.Repositories.Interfaces;

using Dapper;

namespace WebApp.Service
{
    public class RiderService : IRiderService
    {
        private IRiderRepository _riderRepo;

        public RiderService(IRiderRepository riderRepo)
        {
            _riderRepo = riderRepo;
        }
        public async Task<IEnumerable<Rider>> GetAll()
        {
            return await _riderRepo.GetAll();
        }

        public async Task Create(Rider rider)
        {
            //TODO: Business Logic goes here 
            if(rider.Id < 0)
            {
                throw new Exception("Rider not Valid!");
            }

            await _riderRepo.Create(rider);
        }

        public async Task Delete(int id)
        {
            //TODO: Business Logic goes here 
            if (id == null)
            {
                throw new Exception("Driver is NULL!");
            }

            await _riderRepo.Delete(id);
        }

        public async Task Edit(Rider rider)
        {
            //TODO: Business Logic goes here 
            if (rider.RiderName == null)
            {
                throw new Exception("Driver is NULL!");
            }

            await _riderRepo.Edit(rider);
        }

        public async Task<IEnumerable<Rider>> GetRider(int id)
        {
            return await _riderRepo.GetRider(id);
        }
    }
}
