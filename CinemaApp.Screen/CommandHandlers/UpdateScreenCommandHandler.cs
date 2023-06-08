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
    public class UpdateScreenCommandHandler : IRequestHandler<UpdateScreenCommand,int>
    {
        private readonly IScreenService _screenService;

        public UpdateScreenCommandHandler(IScreenService screenService)
        {
            _screenService = screenService;
        }
        public async Task<int> Handle(UpdateScreenCommand command, CancellationToken cancellationToken)
        {
            var screen = await _screenService.GeScreenById(command.Id);

            screen.ScreenName = command.ScreenName;
            screen.Seats = command.Seats;

            return await _screenService.UpdateScreen(screen);
        }
        
    }
}
