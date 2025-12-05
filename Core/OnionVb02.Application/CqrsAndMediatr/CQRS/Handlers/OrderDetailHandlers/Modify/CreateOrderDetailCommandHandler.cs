using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderDetailHandlers.Modify
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IOrderDetailRepository _repository;

        public CreateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync
                (
                    new Domain.Entities.OrderDetail
                    {
                        OrderId = command.OrderId,
                        ProductId = command.ProductId,
                        Status = Domain.Enums.DataStatus.Inserted,
                        CreatedDate = DateTime.Now
                    }
                );
        }
    }
}

