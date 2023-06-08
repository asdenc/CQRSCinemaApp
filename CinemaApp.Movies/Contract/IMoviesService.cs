namespace CinemaApp.Movies.Contract
{
    public interface IMoviesService
    {
        Task<IEnumerable<CinemaApp.Models.Models.Movies>> GeMoviesList();
        Task<CinemaApp.Models.Models.Movies> GetMoviesById(int id);
        Task<CinemaApp.Models.Models.Movies> CreateMovies(CinemaApp.Models.Models.Movies movies);
        Task<int> UpdateMovies(CinemaApp.Models.Models.Movies movies);
        Task<int> DeleteMovies(CinemaApp.Models.Models.Movies movies);
    }
}
