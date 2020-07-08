using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using WebApp.Core.Models;

namespace WebApp.Data.Repositories.Interfaces
{
    
    public interface IRiderRepository
    {
        Task Create(Rider rider);

        Task<IEnumerable<Rider>> GetAll();

        Task Delete(int id);

        Task Edit(Rider rider);

        Task<IEnumerable<Rider>> GetRider(int id);

    }
}
