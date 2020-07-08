using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using WebApp.Core.Models;

using Dapper;


namespace WebApp.Service.Interfaces
{
    public interface IDriverService
    {
        Task<IEnumerable<Driver>> GetAll();
        Task<IEnumerable<Driver>> GetDriver(int id);
        Task Delete(int id);
        Task Edit(Driver driver);
        Task Create(Driver driver);


    }
}
