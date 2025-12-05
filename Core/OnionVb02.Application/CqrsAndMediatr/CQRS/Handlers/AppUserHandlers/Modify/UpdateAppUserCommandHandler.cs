using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserHandlers.Modify
{
    public class UpdateAppUserCommandHandler
    {
        private readonly IAppUserRepository repository;
        private readonly IMapper _mapper;

        public UpdateAppUserCommandHandler(IAppUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAppUserCommand command)
        {
            AppUser value = await repository.GetByIdAsync(command.Id);
            _mapper.Map(command, value);
            value.Status = Domain.Enums.DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;

            await repository.SaveChangesAsync();
        }
    }
}

