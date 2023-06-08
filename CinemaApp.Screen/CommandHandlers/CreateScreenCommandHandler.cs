using CinemaApp.Screen.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.Screen.CommandModels.ScreenCommands;

namespace CinemaApp.Screen.CommandHandlers
{
    public class CreateScreenCommandHandler : IRequestHandler<CreateScreenCommand, Models.Models.Screen>
    {
        private readonly IScreenService _screenService;

        public CreateScreenCommandHandler(IScreenService screenService)
        {
            _screenService = screenService;
        }
        public async Task<Models.Models.Screen> Handle(CreateScreenCommand command, CancellationToken cancellationToken)
        {
            var screen = new Models.Models.Screen()
            {
                ScreenName = command.ScreenName,
                Seats = command.Seats,
            };

            return await _screenService.CreateScreen(screen);
        }
    }
}
