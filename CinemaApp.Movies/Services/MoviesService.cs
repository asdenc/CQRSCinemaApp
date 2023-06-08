using CinemaApp.Movies.Contract;
using CinemaAppInfra;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Movies.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<Models.Models.Movies> CreateMovies(Models.Models.Movies movies)
        {
            _context.Movies.Add(movies);
            await _context.SaveChangesAsync();
            return movies;
        }

        public async Task<int> DeleteMovies(Models.Models.Movies movies)
        {
            _context.Movies.Remove(movies);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Models.Models.Movies>> GeMoviesList()
        {
            return await _context.Movies
            .ToListAsync();
        }

        public async Task<Models.Models.Movies> GetMoviesById(int id)
        {
            if (id == 0)
            {
                throw new Exception();
            }

            var movies = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if (movies == null)
            {
                throw new Exception();
            }
            else
            {
                return movies;
            }
        }

        public async Task<int> UpdateMovies(Models.Models.Movies movies)
        {
            _context.Movies.Update(movies);
            return await _context.SaveChangesAsync();
        }
    }
}
