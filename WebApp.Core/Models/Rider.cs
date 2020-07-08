using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Core.Models
{
    public class Rider
    {
        public int Id { get; set; }
        public string RiderName { get; set; }
        public decimal RiderRating { get; set; }
        public string RiderPhone { get; set; }
        public Guid RiderUberId { get; set; }
        public bool IsActive { get; set; }


    }
}
