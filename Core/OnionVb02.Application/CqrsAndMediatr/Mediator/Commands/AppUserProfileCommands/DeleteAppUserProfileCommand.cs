using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands
{
    public class DeleteAppUserProfileCommand : IRequest
    {
        public int Id { get; set; }
    }
}

