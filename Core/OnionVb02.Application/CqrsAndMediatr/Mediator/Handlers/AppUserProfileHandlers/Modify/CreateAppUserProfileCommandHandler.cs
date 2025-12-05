using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.AppUserProfileHandlers.Modify
{
    public class CreateAppUserProfileCommandHandler : IRequestHandler<CreateAppUserProfileCommand>
    {
        private readonly IAppUserProfileRepository _repository;

        public CreateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = new AppUserProfile
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                AppUserId = request.AppUserId,
                Status = Domain.Enums.DataStatus.Inserted,
                CreatedDate = DateTime.Now
            };

            await _repository.CreateAsync(profile);
        }
    }
}

