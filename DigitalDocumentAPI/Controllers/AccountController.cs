using AutoMapper;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Core.Models;
using Shared.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Triplex.Validations;
using DigitalDocumentAPI.Helpers;
using Shared.ViewModels.PasswordChange;
using Shared.Enums;
using Core.Services;
using Shared.ViewModels.Legalization;

namespace DigitalDocumentAPI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AccountController(IUserService userService, IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            Arguments.NotNull(loginModel, nameof(loginModel));

            User user = _mapper.Map<User>(loginModel);

            User userLogged = await _userService.Login(user);

            var claims = new[] {
                        new Claim("id", userLogged.Id.ToString()),
                        new Claim("lastname", userLogged.Lastname),
                        new Claim("name", userLogged.Name),
                        new Claim("email", userLogged.Email),
                        new Claim("isadmin", userLogged.Role.RoleType == RoleType.Administrator ? true.ToString() : false.ToString())
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: signIn);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        [HttpPost("create-change-password")]
        public async Task<IActionResult> RequestPasswordChange([FromBody] LoginModel loginModel)
        {
            Arguments.NotNull(loginModel, nameof(loginModel));

            Guid id = await _userService.CreateChangeRequest(loginModel.Email);

            return Ok(new { Id = id });
        }

        [HttpGet("validate-password-change")]
        public async Task<IActionResult> ValidatePasswordChange([FromQuery] Guid id) 
        {
            Arguments.NotEmpty(id, nameof(id));

            await _userService.ValidateChangeRequest(id);

            return Ok();
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] PasswordChangeResponse changeResponse)
        {
            Arguments.NotNull(changeResponse, nameof(changeResponse));

            await _userService.ChangePassword(changeResponse);

            return Ok();
        }
    }
}
