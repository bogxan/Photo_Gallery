using Microsoft.AspNetCore.Mvc;
using PhotosAPI.Business.Interfaces;
using PhotosAPI.DTO.Auth;
using PhotosAPI.DTO.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotosAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        IUsersService _usersService;
        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<JwtResponse> Login([FromBody] LoginDto model)
        {
            if (model!=null)
            {
                return await _usersService.Login(model);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto model)
        {
            if (model != null)
            {
                await _usersService.AddUser(model);
                return new JsonResult(new
                {
                    Message = "Success",
                    Code = 200
                });
            }
            else
            {
                return new JsonResult(new
                {
                    Message = "Error",
                    Code = 404
                });
            }
        }
    }
}
