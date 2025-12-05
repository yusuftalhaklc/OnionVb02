using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.AppUserResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserHandlers.Read
{
    public class GetAppUserQueryHandler
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public GetAppUserQueryHandler(IAppUserRepository appUserRepository, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAppUserQueryResult>> Handle()
        {
            List<AppUser> appUser = await _appUserRepository.GetAllAsync();
            return _mapper.Map<List<GetAppUserQueryResult>>(appUser);
        }
    }
}

