using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserProfileHandlers.Modify
{
    public class UpdateAppUserProfileCommandHandler
    {
        private readonly IAppUserProfileRepository repository;

        public UpdateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateAppUserProfileCommand command)
        {
            AppUserProfile value = await repository.GetByIdAsync(command.Id);
            value.FirstName = command.FirstName;
            value.LastName = command.LastName;
            value.AppUserId = command.AppUserId;
            value.Status = Domain.Enums.DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;

            await repository.SaveChangesAsync();
        }
    }
}

