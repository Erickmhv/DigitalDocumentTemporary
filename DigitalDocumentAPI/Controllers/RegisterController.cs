using AutoMapper;
using Core.Models;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;
using Triplex.Validations;
using DigitalDocumentAPI.Helpers;

namespace DigitalDocumentAPI.Controllers
{
  public class RegisterController : BaseController
  {
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public RegisterController(IUserService userService, IMapper mapper)
    {
      _mapper = mapper;
      _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]UserModel userModel)
    {
      Arguments.NotNull(userModel, nameof(userModel));

      User user = _mapper.Map<User>(userModel);

      await _userService.Create(user);

      return Ok();
    }
  }
}
