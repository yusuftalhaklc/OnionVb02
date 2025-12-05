using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.CategoryQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.CategoryHandlers.Read
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<GetCategoryQueryResult>>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Category> values = await _repository.GetAllAsync();
            return values.Select(
                x => new GetCategoryQueryResult 
                { 
                    Id = x.Id,
                    CategoryName = x.CategoryName, 
                    Description = x.Description
                }).ToList();
        }
    }
}

