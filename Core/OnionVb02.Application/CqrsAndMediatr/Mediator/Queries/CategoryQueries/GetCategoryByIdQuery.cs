using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery : IRequest<GetCategoryByIdQueryResult>
    {
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

