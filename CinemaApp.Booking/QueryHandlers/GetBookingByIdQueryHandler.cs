using CinemaApp.Bookings.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Booking.QueryModels.BookingQueries;
namespace CinemaApp.Booking.Queries
{
    public class GetBookingByIdQueryHandler  : IRequestHandler<GetBookingByIdQuery, Models.Models.Booking>
    {
        private readonly IBookingService _bookingService;

        public GetBookingByIdQueryHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<Models.Models.Booking> Handle(GetBookingByIdQuery query, CancellationToken cancellationToken)
        {
            return await _bookingService.GetBookingById(query.Id);
        }

    }
}
