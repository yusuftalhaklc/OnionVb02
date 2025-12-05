using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.ProductHandlers.Modify
{
    public class UpdateProductCommandHandler
    {
        private readonly IProductRepository repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateProductCommand command)
        {
            Product value = await repository.GetByIdAsync(command.Id);
            value.ProductName = command.ProductName;
            value.UnitPrice = command.UnitPrice;
            value.CategoryId = command.CategoryId;
            value.Status = Domain.Enums.DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;

            await repository.SaveChangesAsync();
        }
    }
}

