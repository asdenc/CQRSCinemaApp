using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Booking.QueryModels
{
    public class BookingQueries
    {
        public class GetBookingByIdQuery : IRequest<Models.Models.Booking>
        {
            public int Id { get; set; }
        }
        public class GetAllBookingQuery : IRequest<IEnumerable<Models.Models.Booking>>
        {
           
        }
    }
}
