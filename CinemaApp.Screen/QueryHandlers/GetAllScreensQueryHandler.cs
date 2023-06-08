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
    public class GetAllScreensQueryHandler : IRequestHandler<GetAllScreenQuery, IEnumerable<Models.Models.Screen>>
    {
        private readonly IScreenService _screenService;
        public GetAllScreensQueryHandler(IScreenService screenService) 
        {
            _screenService = screenService;
        }

        public async Task<IEnumerable<Models.Models.Screen>> Handle(GetAllScreenQuery query, CancellationToken cancellationToken)
        {
            return await _screenService.GetScreenList();
        }
    }
}
