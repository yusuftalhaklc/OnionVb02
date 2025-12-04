using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class CreateCategoryCommandHandler
    {
        private readonly ICategoryRepository repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            await repository.CreateAsync
                (
                    new Domain.Entities.Category
                    {
                        CategoryName = command.CategorName,
                        Description = command.Description,
                        Status = Domain.Enums.DataStatus.Inserted,
                        CreatedDate = DateTime.Now
                    }
                );
        }
    }
}
