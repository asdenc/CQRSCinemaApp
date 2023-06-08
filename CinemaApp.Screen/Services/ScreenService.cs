using CinemaApp.Screen.Contract;
using CinemaAppInfra;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Screen.Services
{
    public class ScreenService : IScreenService
    {
        private readonly AppDbContext _context;

        public ScreenService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<Models.Models.Screen> CreateScreen(Models.Models.Screen screen)
        {
            _context.Screen.Add(screen);
            await _context.SaveChangesAsync();
            return screen;
        }

        public async Task<int> DeleteScreen(Models.Models.Screen screen)
        {
            _context.Screen.Remove(screen);
            return await _context.SaveChangesAsync();
        }

        public async Task<Models.Models.Screen> GeScreenById(int id)
        {
            if (id == 0)
            {
                throw new Exception();
            }

            var screen = await _context.Screen.FirstOrDefaultAsync(x => x.Id == id);

            if (screen == null)
            {
                throw new Exception();
            }
            else
            {
                return screen;
            }
        }

        public async Task<IEnumerable<Models.Models.Screen>> GetScreenList()
        {
            return await _context.Screen
           .ToListAsync();
        }

        public async Task<int> UpdateScreen(Models.Models.Screen screen)
        {
            throw new NotImplementedException();
        }
    }
}
