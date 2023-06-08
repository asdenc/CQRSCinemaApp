using CinemaApp.Bookings.Contract;
using CinemaAppInfra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Bookings.Services
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Models.Booking> CreateBooking(Models.Models.Booking booking)
        {
            _context.Booking.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<int> DeleteBooking(Models.Models.Booking booking)
        {
            _context.Booking.Remove(booking);
            return await _context.SaveChangesAsync();
        }

        public async Task<Models.Models.Booking> GetBookingById(int id)
        {

            if(id == 0) 
            {
                throw new Exception();
            }

            var booking = await _context.Booking.FirstOrDefaultAsync(x => x.Id == id);

            if (booking == null)
            {
                throw new Exception();
            }
            else 
            {
                return booking;
            }
          
        }

        public async Task<IEnumerable<Models.Models.Booking>> GetBookingList()
        {
            return await _context.Booking
             .ToListAsync();
        }

        public async Task<int> UpdateBooking(Models.Models.Booking booking)
        {
            _context.Booking.Update(booking);
            return await _context.SaveChangesAsync();
        }
    }
}
