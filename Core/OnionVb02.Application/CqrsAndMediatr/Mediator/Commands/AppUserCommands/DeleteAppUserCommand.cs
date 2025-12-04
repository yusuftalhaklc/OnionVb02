using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands
{
    public class DeleteAppUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
