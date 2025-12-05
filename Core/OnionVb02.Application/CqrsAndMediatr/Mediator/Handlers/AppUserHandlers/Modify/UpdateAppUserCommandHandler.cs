using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.AppUserHandlers.Modify
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand>
    {
        private readonly IAppUserRepository _repository;

        public UpdateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);

            if (user == null)
                throw new Exception("User not found");

            user.UserName = request.Username;
            user.Password = request.Password;
            user.Status = Domain.Enums.DataStatus.Updated;
            user.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();
        }
    }
}

