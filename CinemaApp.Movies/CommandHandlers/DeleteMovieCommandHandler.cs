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
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, int>
    {
        private readonly IMoviesService _moviesService;
        public DeleteMovieCommandHandler(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public async Task<int> Handle(DeleteMovieCommand command, CancellationToken cancellationToken)
        {
            var movie = await _moviesService.GetMoviesById(command.Id);
            return await _moviesService.DeleteMovies(movie);
        }
    }
}
