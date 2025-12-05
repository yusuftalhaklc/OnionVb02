using AutoMapper;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.AppUserProfileHandlers.Modify
{
    public class CreateAppUserProfileCommandHandler : IRequestHandler<CreateAppUserProfileCommand>
    {
        private readonly IAppUserProfileRepository _repository;
        private readonly IMapper _mapper;

        public CreateAppUserProfileCommandHandler(IAppUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = _mapper.Map<AppUserProfile>(request);
            profile.Status = Domain.Enums.DataStatus.Inserted;
            profile.CreatedDate = DateTime.Now;

            await _repository.CreateAsync(profile);
        }
    }
}

