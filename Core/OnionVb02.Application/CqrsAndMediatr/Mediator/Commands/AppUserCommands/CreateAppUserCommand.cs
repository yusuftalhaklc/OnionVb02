using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands
{
    // Ödev : Command generic Irequest
    public class CreateAppUserCommand : IRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
