using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserHandlers.Modify
{
    public class CreateAppUserCommandHandler
    {
        private readonly IAppUserRepository _repository;
        private readonly IMapper _mapper;

        public CreateAppUserCommandHandler(IAppUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAppUserCommand command)
        {
            var appUser = _mapper.Map<AppUser>(command);
            appUser.Status = Domain.Enums.DataStatus.Inserted;
            appUser.CreatedDate = DateTime.Now;
            
            await _repository.CreateAsync(appUser);
        }
    }
}

