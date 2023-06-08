using MediatR;

namespace CinemaApp.Screen.QueryModels
{
    public class ScreenQueries
    {
        public class GetScreenByIdQuery : IRequest<Models.Models.Screen>
        {
            public int Id { get; set; }
        }
        public class GetAllScreenQuery : IRequest<IEnumerable<Models.Models.Screen>>
        {

        }
    }
}
