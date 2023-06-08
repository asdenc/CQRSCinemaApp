using CinemaApp.Movies.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Movies.QueryModels.MoviesQueries;

namespace CinemaApp.Movies.QueryHandlers
{
    public class GetMoviesByIdQueryHandler : IRequestHandler<GetMoviesByIdQuery, Models.Models.Movies>
    {
        private readonly IMoviesService _movieService;

        public GetMoviesByIdQueryHandler(IMoviesService movieService)
        {
            _movieService = movieService;
        }
        public async Task<Models.Models.Movies> Handle(GetMoviesByIdQuery query, CancellationToken cancellationToken)
        {
            return await _movieService.GetMoviesById(query.Id);
        }
    }
}
