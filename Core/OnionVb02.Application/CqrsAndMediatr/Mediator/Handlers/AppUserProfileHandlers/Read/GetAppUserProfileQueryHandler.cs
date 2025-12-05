using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserProfileQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.AppUserProfileHandlers.Read
{
    public class GetAppUserProfileQueryHandler : IRequestHandler<GetAppUserProfileQuery, List<GetAppUserProfileQueryResult>>
    {
        private readonly IAppUserProfileRepository _repository;

        public GetAppUserProfileQueryHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAppUserProfileQueryResult>> Handle(GetAppUserProfileQuery request, CancellationToken cancellationToken)
        {
            List<AppUserProfile> values = await _repository.GetAllAsync();
            return values.Select(
                x => new GetAppUserProfileQueryResult 
                { 
                    Id = x.Id,
                    FirstName = x.FirstName, 
                    LastName = x.LastName,
                    AppUserId = x.AppUserId
                }).ToList();
        }
    }
}

