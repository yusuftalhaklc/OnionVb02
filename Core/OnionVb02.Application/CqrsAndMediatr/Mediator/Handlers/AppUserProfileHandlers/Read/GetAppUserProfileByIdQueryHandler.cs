using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserProfileQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.AppUserProfileHandlers.Read
{
    public class GetAppUserProfileByIdQueryHandler : IRequestHandler<GetAppUserProfileByIdQuery, GetAppUserProfileByIdQueryResult>
    {
        private readonly IAppUserProfileRepository _repository;

        public GetAppUserProfileByIdQueryHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAppUserProfileByIdQueryResult> Handle(GetAppUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            AppUserProfile profile = await _repository.GetByIdAsync(request.Id);

            if (profile == null)
                throw new Exception("AppUserProfile not found");

            return new GetAppUserProfileByIdQueryResult
            {
                Id = profile.Id,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                AppUserId = profile.AppUserId
            };
        }
    }
}

