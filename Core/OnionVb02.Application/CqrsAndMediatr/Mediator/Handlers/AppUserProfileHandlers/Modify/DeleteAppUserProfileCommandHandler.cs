using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.AppUserProfileHandlers.Modify
{
    public class DeleteAppUserProfileCommandHandler : IRequestHandler<DeleteAppUserProfileCommand>
    {
        private readonly IAppUserProfileRepository _repository;

        public DeleteAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            AppUserProfile value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}

