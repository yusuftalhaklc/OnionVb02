using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.AppUserQueries;
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
    public class GetAppUserByIdQueryHandler
    {
        private readonly IAppUserRepository _appUserRepository;

        public GetAppUserByIdQueryHandler(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<GetAppUserByIdQueryResult> Handle(GetAppUserByIdQuery query)
        {
            AppUser appUser = await _appUserRepository.GetByIdAsync(query.Id);

            return new GetAppUserByIdQueryResult
            {
                Id = appUser.Id,
                UserName = appUser.UserName,
                Password = appUser.Password
            };
        }
    }
}

