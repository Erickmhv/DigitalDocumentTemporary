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
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _mapper = mapper;
            _roleService = roleService;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RoleModel roleModel)
        {
            Arguments.NotNull(roleModel, nameof(roleModel));

            Role role = _mapper.Map<Role>(roleModel);

            await _roleService.Update(role);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] Guid roleId)
        {
            Arguments.NotEmpty(roleId, nameof(roleId));

            Role role = await _roleService.GetById(roleId);
            RoleInformation roleInfo = _mapper.Map<RoleInformation>(role);

            return Ok(roleInfo);
        }
    }
}
