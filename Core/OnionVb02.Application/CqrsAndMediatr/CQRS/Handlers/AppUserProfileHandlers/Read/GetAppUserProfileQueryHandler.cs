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
    public class GetAppUserProfileQueryHandler
    {
        private readonly IAppUserProfileRepository _appUserProfileRepository;

        public GetAppUserProfileQueryHandler(IAppUserProfileRepository appUserProfileRepository)
        {
            _appUserProfileRepository = appUserProfileRepository;
        }
        // Todo: Mapper profiles için ödev
        public async Task<List<GetAppUserProfileQueryResult>> Handle()
        {
            List<AppUserProfile> appUserProfile = await _appUserProfileRepository.GetAllAsync();

            return appUserProfile.Select(p => new GetAppUserProfileQueryResult
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                AppUserId = p.AppUserId
            }).ToList();
        }
    }
}

