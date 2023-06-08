using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Booking.CommandModels
{
    public  class BookingCommands
    {
        public class CreateBookingCommand : IRequest<Models.Models.Booking>
        {
            public string? Reference { get; set; }
            public int CustomerId { get; set; }
            public int MovieId { get; set; }
            public int ScreenId { get; set; }
        }
        public class UpdateBookingCommand : IRequest<int>
        {
            public int Id { get; set; }
            public string? Reference { get; set; }
            public int CustomerId { get; set; }
            public int MovieId { get; set; }
            public int ScreenId { get; set; }
        }
        public class DeleteBookingCommand : IRequest<int>
        {
            public int Id { get; set; }
        }
    }
}
