using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.DTOClasses;
using OnionVb02.Application.ManagerInterfaces;
using OnionVb02.WebApi.RequestModels.AppUsers;
using OnionVb02.WebApi.ResponseModels.AppUsers;

namespace OnionVb02.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserManager _appUserManager;
        private readonly IMapper _mapper;

        public AppUserController(IAppUserManager appUserManager, IMapper mapper)
        {
            _appUserManager = appUserManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AppUserList()
        {
            List<AppUserDto> values = await _appUserManager.GetAllAsync();
            return Ok(_mapper.Map<List<AppUserResponseModel>>(values));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUser(int id)
        {
            AppUserDto value = await _appUserManager.GetByIdAsync(id);
            return Ok(_mapper.Map<AppUserResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateAppUserRequestModel model)
        {
            AppUserDto appUser = _mapper.Map<AppUserDto>(model);
            await _appUserManager.CreateAsync(appUser);
            return Ok("Veri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUser(UpdateAppUserRequestModel model)
        {
            AppUserDto appUser = _mapper.Map<AppUserDto>(model);
            await _appUserManager.UpdateAsync(appUser);
            return Ok("Veri güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteAppUser(int id)
        {
            string result = await _appUserManager.SoftDeleteAsync(id);
            return Ok(result);
        }

        [HttpDelete("hard/{id}")]
        public async Task<IActionResult> HardDeleteAppUser(int id)
        {
            string result = await _appUserManager.HardDeleteAsync(id);
            return Ok(result);
        }
    }
}

