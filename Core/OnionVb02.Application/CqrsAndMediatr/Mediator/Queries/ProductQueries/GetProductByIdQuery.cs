using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries
{
    public class GetProductByIdQuery : IRequest<GetProductByIdQueryResult>
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

