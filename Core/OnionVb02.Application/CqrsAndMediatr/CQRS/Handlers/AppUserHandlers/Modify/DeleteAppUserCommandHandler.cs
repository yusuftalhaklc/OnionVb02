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
    public class DeleteAppUserCommandHandler
    {
        private readonly IAppUserRepository repository;

        public DeleteAppUserCommandHandler(IAppUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(DeleteAppUserCommand command)
        {
            AppUser value = await repository.GetByIdAsync(command.Id);

            /* Soft Delete işlemi 
                value.Status = Domain.Enums.DataStatus.Deleted;
                value.DeletedDate = DateTime.Now;
                await repository.SaveChangesAsync;
            */

            await repository.DeleteAsync(value);
        }
    }
}

