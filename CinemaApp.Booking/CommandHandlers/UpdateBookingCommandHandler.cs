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
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, int>
    {
        private readonly IBookingService _bookingService;

        public UpdateBookingCommandHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public async Task<int> Handle(UpdateBookingCommand command, CancellationToken cancellationToken)
        {
            var booking = await _bookingService.GetBookingById(command.Id);

            booking.ScreenId = command.ScreenId;
            booking.Reference = command.Reference;
            booking.MovieId = command.MovieId;
            booking.CustomerId = command.CustomerId;
            

            return await _bookingService.UpdateBooking(booking);
        }
    }
}
