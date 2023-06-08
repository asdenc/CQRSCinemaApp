using MediatR;

namespace CinemaApp.Movies.QueryModels
{
    public class MoviesQueries
    {
        public class GetMoviesByIdQuery : IRequest<Models.Models.Movies>
        {
            public int Id { get; set; }
        }
        public class GetAllMoviesQuery : IRequest<IEnumerable<Models.Models.Movies>>
        {

        }
    }
}
