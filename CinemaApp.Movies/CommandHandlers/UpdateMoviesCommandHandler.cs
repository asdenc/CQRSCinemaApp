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
    public class UpdateMoviesCommandHandler : IRequestHandler<UpdateMovieCommand, int>
    {
        private readonly IMoviesService _moviesService;
        public UpdateMoviesCommandHandler(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public async Task<int> Handle(UpdateMovieCommand command, CancellationToken cancellationToken)
        {
            var movie = await _moviesService.GetMoviesById(command.Id);

            movie.ScreenId = command.ScreenId;
            movie.Name = command.Name;
            movie.ReleaseDate = command.ReleaseDate;

            return await _moviesService.UpdateMovies(movie);
        }
    }
}
