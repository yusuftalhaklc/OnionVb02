using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderHandlers.Modify
{
    public class CreateOrderCommandHandler
    {
        private readonly IOrderRepository _repository;

        public CreateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderCommand command)
        {
            await _repository.CreateAsync
                (
                    new Domain.Entities.Order
                    {
                        ShippingAddress = command.ShippingAddress,
                        AppUserId = command.AppUserId,
                        Status = Domain.Enums.DataStatus.Inserted,
                        CreatedDate = DateTime.Now
                    }
                );
        }
    }
}

