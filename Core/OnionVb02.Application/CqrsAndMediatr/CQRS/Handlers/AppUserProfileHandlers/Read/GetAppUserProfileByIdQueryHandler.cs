using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.AppUserProfileQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.AppUserProfileResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserProfileHandlers.Read
{
    public class GetAppUserProfileByIdQueryHandler
    {
        private readonly IAppUserProfileRepository _appUserProfileRepository;

        public GetAppUserProfileByIdQueryHandler(IAppUserProfileRepository appUserProfileRepository)
        {
            _appUserProfileRepository = appUserProfileRepository;
        }

        public async Task<GetAppUserProfileByIdQueryResult> Handle(GetAppUserProfileByIdQuery query)
        {
            AppUserProfile appUserProfile = await _appUserProfileRepository.GetByIdAsync(query.Id);

            return new GetAppUserProfileByIdQueryResult
            {
                Id = appUserProfile.Id,
                FirstName = appUserProfile.FirstName,
                LastName = appUserProfile.LastName,
                AppUserId = appUserProfile.AppUserId
            };
        }
    }
}

