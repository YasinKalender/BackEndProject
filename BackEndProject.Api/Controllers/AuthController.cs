using BackEndProject.Business.Interfaces;
using BackEndProject.DTOs.DTO.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        //[Authorize(Roles ="Admin")]
        public ActionResult Login(UserLoginDto userLoginDto)
        {
            var user = _authService.Login(userLoginDto);
            var result = _authService.CreateToken(user.Data);

            return Ok(result);
        }

        [HttpPost("register")]
        public ActionResult Register(UserRegisterDto userRegisterDto)
        {
            var user = _authService.Register(userRegisterDto, userRegisterDto.Password);
         


            return Ok(user);
        }
    }
}
