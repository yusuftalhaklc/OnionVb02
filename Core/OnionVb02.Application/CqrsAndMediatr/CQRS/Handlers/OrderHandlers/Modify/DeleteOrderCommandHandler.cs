using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderHandlers.Modify
{
    public class DeleteOrderCommandHandler
    {
        private readonly IOrderRepository repository;

        public DeleteOrderCommandHandler(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(DeleteOrderCommand command)
        {
            Order value = await repository.GetByIdAsync(command.Id);

            /* Soft Delete işlemi 
                value.Status = Domain.Enums.DataStatus.Deleted;
                value.DeletedDate = DateTime.Now;
                await repository.SaveChangesAsync;
            */

            await repository.DeleteAsync(value);
        }
    }
}

