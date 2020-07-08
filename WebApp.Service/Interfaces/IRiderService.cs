using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;

using WebApp.Core.Models;

namespace WebApp.Service.Interfaces
{
    public interface IRiderService
    {
        Task<IEnumerable<Rider>> GetAll();
        Task<IEnumerable<Rider>> GetRider(int id);
        Task Delete(int id);
        Task Edit(Rider rider);
        Task Create(Rider rider);


    }
}
