using CinemaApp.Screen.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Screen.QueryModels.ScreenQueries;

namespace CinemaApp.Screen.QueryHandlers
{
    public class GetScreenByIdQueryHandler : IRequestHandler<GetScreenByIdQuery, Models.Models.Screen>
    {
        private readonly IScreenService _screenService;
        public GetScreenByIdQueryHandler(IScreenService screenService)
        {
            _screenService = screenService;
        }

        public async Task<Models.Models.Screen> Handle(GetScreenByIdQuery query, CancellationToken cancellationToken)
        {
            return await _screenService.GeScreenById(query.Id);
        }
    }
}
