using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.AppUserProfileResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserProfileHandlers.Read
{
    public class GetAppUserProfileQueryHandler
    {
        private readonly IAppUserProfileRepository _appUserProfileRepository;
        private readonly IMapper _mapper;

        public GetAppUserProfileQueryHandler(IAppUserProfileRepository appUserProfileRepository, IMapper mapper)
        {
            _appUserProfileRepository = appUserProfileRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAppUserProfileQueryResult>> Handle()
        {
            List<AppUserProfile> appUserProfile = await _appUserProfileRepository.GetAllAsync();
            return _mapper.Map<List<GetAppUserProfileQueryResult>>(appUserProfile);
        }
    }
}

