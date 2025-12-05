using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserHandlers.Modify
{
    public class UpdateAppUserCommandHandler
    {
        private readonly IAppUserRepository repository;

        public UpdateAppUserCommandHandler(IAppUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateAppUserCommand command)
        {
            AppUser value = await repository.GetByIdAsync(command.Id);
            value.UserName = command.UserName;
            value.Password = command.Password;
            value.Status = Domain.Enums.DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;

            await repository.SaveChangesAsync();
        }
    }
}

