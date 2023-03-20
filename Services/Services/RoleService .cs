using AutoMapper;
using Core.Models;
using Core.Services.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Optional;
using Optional.Unsafe;
using Shared.Enums;
using Shared.ViewModels.PasswordChange;
using Shared.ViewModels.User;
using System.Text.RegularExpressions;
using Triplex.Validations;

namespace Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepo;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepo = roleRepository;
            _mapper = mapper;
        }

        async Task IRoleService.Create(Role role)
        {
            Arguments.NotNull(role, nameof(role));

            RoleDbModel roleDbModel = _mapper.Map<RoleDbModel>(role);

            await this._roleRepo.Create(roleDbModel);
        }

        async Task IRoleService.Update(Role role)
        {
            Arguments.NotNull(role, nameof(role));

            RoleDbModel roleDbModel = _mapper.Map<RoleDbModel>(role);
            RoleDbModel roleToUpdate = (await _roleRepo.GetById(role.Id)).ValueOrFailure("Este rol no existe")!;

            roleToUpdate.Map(roleDbModel);

            await this._roleRepo.Update(roleToUpdate);
        }

        async Task<Role> IRoleService.GetById(Guid roleId) 
        {
            Arguments.NotEmpty(roleId, nameof(roleId));

            RoleDbModel roleDbModel = (await _roleRepo.GetById(roleId)).ValueOrFailure("Este rol no existe.")!;

            return _mapper.Map<Role>(roleDbModel);
        }
    }
}
