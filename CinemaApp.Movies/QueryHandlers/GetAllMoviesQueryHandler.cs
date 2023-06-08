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
    public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<Models.Models.Movies>>
    {
        private readonly IMoviesService _movieService;

        public GetAllMoviesQueryHandler(IMoviesService movieService)
        {
            _movieService = movieService;
        }
        public async Task<IEnumerable<Models.Models.Movies>> Handle(GetAllMoviesQuery query, CancellationToken cancellationToken)
        {
            return await _movieService.GeMoviesList();
        }
    }
}
