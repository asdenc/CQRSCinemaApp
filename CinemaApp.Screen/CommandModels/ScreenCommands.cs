using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Screen.CommandModels
{
    public class ScreenCommands
    {
        public class CreateScreenCommand : IRequest<Models.Models.Screen>
        {
            public string ScreenName { get; set; }
            public int Seats { get; set; }
        }
        public class UpdateScreenCommand : IRequest<int>
        {
            public int Id { get; set; }
            public string ScreenName { get; set; }
            public int Seats { get; set; }
        }
        public class DeleteScreenCommand : IRequest<int>
        {
            public int Id { get; set; }
        }
    }
}
