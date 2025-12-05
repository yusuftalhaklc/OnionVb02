using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserProfileHandlers.Modify
{
    public class CreateAppUserProfileCommandHandler
    {
        private readonly IAppUserProfileRepository _repository;

        public CreateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserProfileCommand command)
        {
            await _repository.CreateAsync
                (
                    new Domain.Entities.AppUserProfile
                    {
                        FirstName = command.FirstName,
                        LastName = command.LastName,
                        AppUserId = command.AppUserId,
                        Status = Domain.Enums.DataStatus.Inserted,
                        CreatedDate = DateTime.Now
                    }
                );
        }
    }
}

