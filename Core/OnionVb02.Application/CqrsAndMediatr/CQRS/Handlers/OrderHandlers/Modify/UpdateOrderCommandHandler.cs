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
    public class UpdateOrderCommandHandler
    {
        private readonly IOrderRepository repository;

        public UpdateOrderCommandHandler(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateOrderCommand command)
        {
            Order value = await repository.GetByIdAsync(command.Id);
            value.ShippingAddress = command.ShippingAddress;
            value.AppUserId = command.AppUserId;
            value.Status = Domain.Enums.DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;

            await repository.SaveChangesAsync();
        }
    }
}

