using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Core.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string DriverName { get; set; }
        public decimal DriverRating { get; set; }
        public string DriverPhone { get; set; }
        public int CompletedRides { get; set; }
        public Guid UberId { get; set; }
        public bool IsActive { get; set; }

    }
}
