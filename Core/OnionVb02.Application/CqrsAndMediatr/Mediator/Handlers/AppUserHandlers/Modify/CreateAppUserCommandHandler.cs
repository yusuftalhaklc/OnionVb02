using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.AppUserHandlers.Modify
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IAppUserRepository _repository;

        public CreateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                UserName = request.Username,
                Password = request.Password,
                Status = Domain.Enums.DataStatus.Inserted,
                CreatedDate = DateTime.Now
            };

            await _repository.CreateAsync(user);
        }
    }
}

