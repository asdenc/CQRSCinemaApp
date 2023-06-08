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
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, int>
    {
        private readonly IBookingService _bookingService;

        public DeleteBookingCommandHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public async Task<int> Handle(DeleteBookingCommand command, CancellationToken cancellationToken)
        {
            var booking = await _bookingService.GetBookingById(command.Id);

            return await _bookingService.DeleteBooking(booking);
        }
    }
}
