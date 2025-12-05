using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.AppUserResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserHandlers.Read
{
    public class GetAppUserQueryHandler
    {
        private readonly IAppUserRepository _appUserRepository;

        public GetAppUserQueryHandler(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }
        // Todo: Mapper profiles için ödev
        public async Task<List<GetAppUserQueryResult>> Handle()
        {
            List<AppUser> appUser = await _appUserRepository.GetAllAsync();

            return appUser.Select(u => new GetAppUserQueryResult
            {
                Id = u.Id,
                UserName = u.UserName,
                Password = u.Password
            }).ToList();
        }
    }
}

