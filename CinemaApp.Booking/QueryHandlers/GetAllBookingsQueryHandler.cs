using CinemaApp.Bookings.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Booking.QueryModels.BookingQueries;

namespace CinemaApp.Bookings.Queries
{
        public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingQuery, IEnumerable<Models.Models.Booking>>
        {
            private readonly IBookingService _bookingService;

            public GetAllBookingsQueryHandler(IBookingService bookingService)
            {
            _bookingService = bookingService;
            }

            public async Task<IEnumerable<Models.Models.Booking>> Handle(GetAllBookingQuery query, CancellationToken cancellationToken)
            {
                return await _bookingService.GetBookingList();
            }
        }

    
}
