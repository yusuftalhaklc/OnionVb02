using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserProfileQueries
{
    public class GetAppUserProfileByIdQuery : IRequest<GetAppUserProfileByIdQueryResult>
    {
        public GetAppUserProfileByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

