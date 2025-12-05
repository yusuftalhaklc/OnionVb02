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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IOrderDetailRepository repository;

        public UpdateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            OrderDetail value = await repository.GetByIdAsync(command.Id);
            value.OrderId = command.OrderId;
            value.ProductId = command.ProductId;
            value.Status = Domain.Enums.DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;

            await repository.SaveChangesAsync();
        }
    }
}

