using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using WebApp.Core.Models;

namespace WebApp.Data.Repositories.Interfaces
{
    
    public interface IDriverRepository
    {
        Task Create(Driver driver);

        Task<IEnumerable<Driver>> GetAll();

        Task Delete(int id);

        Task Edit(Driver driver);

        Task<IEnumerable<Driver>> GetDriver(int id);

    }
}
