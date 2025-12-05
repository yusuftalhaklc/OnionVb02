using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserProfileHandlers.Modify
{
    public class UpdateAppUserProfileCommandHandler
    {
        private readonly IAppUserProfileRepository repository;
        private readonly IMapper _mapper;

        public UpdateAppUserProfileCommandHandler(IAppUserProfileRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAppUserProfileCommand command)
        {
            AppUserProfile value = await repository.GetByIdAsync(command.Id);
            _mapper.Map(command, value);
            value.Status = Domain.Enums.DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;

            await repository.SaveChangesAsync();
        }
    }
}

