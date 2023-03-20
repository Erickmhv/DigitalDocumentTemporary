using AutoMapper;
using Core.Models;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;
using Shared.ViewModels.User;
using Triplex.Validations;
using DigitalDocumentAPI.Helpers;

namespace DigitalDocumentAPI.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserModel userModel)
        {
            Arguments.NotNull(userModel, nameof(userModel));

            User user = _mapper.Map<User>(userModel);

            await _userService.Update(user);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] Guid userId)
        {
            Arguments.NotEmpty(userId, nameof(userId));

            User user = await _userService.GetById(userId);
            UserInformation userInfo = _mapper.Map<UserInformation>(user);

            return Ok(userInfo);
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword(UpdatePassword updatePassword, [FromQuery]Guid userId)
        {
            Arguments.NotNull(updatePassword, nameof(updatePassword));

            await _userService.UpdatePassword(updatePassword, userId);

            return Ok();
        }
    }
}
