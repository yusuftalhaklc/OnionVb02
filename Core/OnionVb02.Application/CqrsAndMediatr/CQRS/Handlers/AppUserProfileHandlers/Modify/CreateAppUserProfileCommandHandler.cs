using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserProfileHandlers.Modify
{
    public class CreateAppUserProfileCommandHandler
    {
        private readonly IAppUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public CreateAppUserProfileCommandHandler(IAppUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAppUserProfileCommand command)
        {
            var appUserProfile = _mapper.Map<AppUserProfile>(command);
            appUserProfile.Status = Domain.Enums.DataStatus.Inserted;
            appUserProfile.CreatedDate = DateTime.Now;
            
            await _repository.CreateAsync(appUserProfile);
        }
    }
}

