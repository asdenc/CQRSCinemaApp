namespace CinemaApp.Bookings.Contract
{
    public interface IBookingService
    {
        Task<IEnumerable<CinemaApp.Models.Models.Booking>> GetBookingList();
        Task<CinemaApp.Models.Models.Booking> GetBookingById(int id);
        Task<CinemaApp.Models.Models.Booking> CreateBooking(CinemaApp.Models.Models.Booking booking);
        Task<int> UpdateBooking(CinemaApp.Models.Models.Booking booking);
        Task<int> DeleteBooking(CinemaApp.Models.Models.Booking booking);
    }
}
