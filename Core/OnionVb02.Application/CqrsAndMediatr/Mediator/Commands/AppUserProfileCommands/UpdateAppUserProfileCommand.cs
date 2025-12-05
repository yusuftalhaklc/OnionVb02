using MediatR;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands
{
    public class UpdateAppUserProfileCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }
    }
}

