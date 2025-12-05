using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands
{
    public class CreateAppUserProfileCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }
    }
}

