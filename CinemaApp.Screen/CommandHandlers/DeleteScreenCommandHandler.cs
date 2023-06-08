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
    public class DeleteScreenCommandHandler: IRequestHandler<DeleteScreenCommand, int>
    {
        private readonly IScreenService _screenService;

        public DeleteScreenCommandHandler(IScreenService screenService)
        {
            _screenService = screenService;
        }
        public async Task<int> Handle(DeleteScreenCommand command, CancellationToken cancellationToken)
        {
            var screen = await _screenService.GeScreenById(command.Id);
            return await _screenService.DeleteScreen(screen);
        }

    }
}
