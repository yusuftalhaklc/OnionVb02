using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.CategoryQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.CategoryHandlers.Read
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            Category category = await _repository.GetByIdAsync(request.Id);

            if (category == null)
                throw new Exception("Category not found");

            return new GetCategoryByIdQueryResult
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }
    }
}

