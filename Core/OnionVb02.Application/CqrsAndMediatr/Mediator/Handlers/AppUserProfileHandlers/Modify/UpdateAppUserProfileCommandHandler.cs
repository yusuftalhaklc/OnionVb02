using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.AppUserProfileHandlers.Modify
{
    public class UpdateAppUserProfileCommandHandler : IRequestHandler<UpdateAppUserProfileCommand>
    {
        private readonly IAppUserProfileRepository _repository;

        public UpdateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _repository.GetByIdAsync(request.Id);

            if (profile == null)
                throw new Exception("AppUserProfile not found");

            profile.FirstName = request.FirstName;
            profile.LastName = request.LastName;
            profile.AppUserId = request.AppUserId;
            profile.Status = Domain.Enums.DataStatus.Updated;
            profile.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();
        }
    }
}

