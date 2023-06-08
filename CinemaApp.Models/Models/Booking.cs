using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Models.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string? Reference { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public int ScreenId { get; set; }

    }
}
