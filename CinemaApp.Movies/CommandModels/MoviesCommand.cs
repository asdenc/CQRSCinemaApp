using MediatR;

namespace CinemaApp.Movies.CommandModels
{
    public class MoviesCommand
    {
        public class CreateMovieCommand : IRequest<Models.Models.Movies>
        {
            public int ScreenId { get; set; }
            public string Name { get; set; }
            public DateTime ReleaseDate { get; set; }
        }
        public class UpdateMovieCommand : IRequest<int>
        {
            public int Id { get; set; }
            public int ScreenId { get; set; }
            public string Name { get; set; }
            public DateTime ReleaseDate { get; set; }
        }
        public class DeleteMovieCommand : IRequest<int>
        {
            public int Id { get; set; }
        }
    }
}
