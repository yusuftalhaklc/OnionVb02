using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.CategoryHandlers.Modify
{
    public class DeleteCategoryCommandHandler
    {
        private readonly ICategoryRepository repository;

        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(DeleteCategoryCommand command)
        {
            Category value = await repository.GetByIdAsync(command.Id);

            /* Soft Delete işlemi 
                value.Status = Domain.Enums.DataStatus.Deleted;
                value.DeletedDate = DateTime.Now;
                await repository.SaveChangesAsync;
            */

            await repository.DeleteAsync(value);
        }
    }
}

