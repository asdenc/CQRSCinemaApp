using CinemaApp.Movies.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Movies.CommandModels.MoviesCommand;

namespace CinemaApp.Movies.CommandHandlers
{
    public class CreateMoviesCommandHandler : IRequestHandler<CreateMovieCommand, Models.Models.Movies>
    {
        private readonly IMoviesService _moviesService;
        public CreateMoviesCommandHandler(IMoviesService moviesService) 
        {
            _moviesService = moviesService;
        }

        public async Task<Models.Models.Movies> Handle(CreateMovieCommand command, CancellationToken cancellationToken)
        {
            var movie = new Models.Models.Movies()
            {
               Name = command.Name,
               ReleaseDate = command.ReleaseDate,
               ScreenId = command.ScreenId,
            };

            return await _moviesService.CreateMovies(movie);
        }
    }
}
