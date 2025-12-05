using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.CategoryHandlers.Modify
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            if (category == null)
                throw new Exception("Category not found");

            category.CategoryName = request.CategoryName;
            category.Description = request.Description;
            category.Status = Domain.Enums.DataStatus.Updated;
            category.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();
        }
    }
}

