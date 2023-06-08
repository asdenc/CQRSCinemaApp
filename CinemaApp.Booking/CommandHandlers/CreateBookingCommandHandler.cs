using CinemaApp.Bookings.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Booking.CommandModels.BookingCommands;

namespace CinemaApp.Booking.Commands
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Models.Models.Booking>
    {
        private readonly IBookingService _bookingService;

        public CreateBookingCommandHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public async Task<Models.Models.Booking> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
        {
            var booking = new Models.Models.Booking()
            {
                CustomerId = command.CustomerId,
                MovieId = command.MovieId,
                Reference = command.Reference,
                ScreenId = command.ScreenId,
            };

            return await _bookingService.CreateBooking(booking);
        }
    }
}
