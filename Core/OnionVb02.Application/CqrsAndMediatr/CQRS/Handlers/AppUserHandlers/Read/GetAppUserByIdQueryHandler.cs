using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.AppUserQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.AppUserResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserHandlers.Read
{
    public class GetAppUserByIdQueryHandler
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public GetAppUserByIdQueryHandler(IAppUserRepository appUserRepository, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }

        public async Task<GetAppUserByIdQueryResult> Handle(GetAppUserByIdQuery query)
        {
            AppUser appUser = await _appUserRepository.GetByIdAsync(query.Id);
            return _mapper.Map<GetAppUserByIdQueryResult>(appUser);
        }
    }
}

