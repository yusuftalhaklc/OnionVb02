using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class UpdateCategoryCommandHandler
    {
        private readonly ICategoryRepository repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            Category value = await repository.GetByIdAsync(command.Id);
            value.CategoryName = command.CategorName;
            value.Description = command.Description;
            value.Status = Domain.Enums.DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;

            await repository.SaveChangesAsync();
        }
    }
}
