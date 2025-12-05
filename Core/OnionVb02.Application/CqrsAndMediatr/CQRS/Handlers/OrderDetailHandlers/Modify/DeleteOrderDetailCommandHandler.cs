using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderDetailHandlers.Modify
{
    public class DeleteOrderDetailCommandHandler
    {
        private readonly IOrderDetailRepository repository;

        public DeleteOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(DeleteOrderDetailCommand command)
        {
            OrderDetail value = await repository.GetByIdAsync(command.Id);

            /* Soft Delete işlemi 
                value.Status = Domain.Enums.DataStatus.Deleted;
                value.DeletedDate = DateTime.Now;
                await repository.SaveChangesAsync;
            */

            await repository.DeleteAsync(value);
        }
    }
}

