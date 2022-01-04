using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearningJWT.Dtos;
using LearningJWT.Models;
using LearningJWT.Repository.Interfaces;
using LearningJWT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearningJWT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AuthController(IAuthRepository repo, ITokenService tokenService, IMapper mapper)
        {
            _repo = repo;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {
            userDto.Email = userDto.Email.ToLower();
            if(await _repo.UserExist(userDto.Email))return BadRequest("user exist");

            var user = _mapper.Map<User>(userDto);

            var createdUser = await _repo.Register(user, userDto.Password);

            var createdUserDto = _mapper.Map<UserDto>(createdUser);

            return Ok(createdUserDto);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userDto)
        {
            var userLog = await _repo.Login(userDto.Email, userDto.Password);
            if(userLog == null) return Unauthorized();

            var token = _tokenService.CreateToken(userLog);
            var user = _mapper.Map<UserDto>(userLog);

            return Ok(new {
                token = token,
                user = user
            });
        }
        
    }
}