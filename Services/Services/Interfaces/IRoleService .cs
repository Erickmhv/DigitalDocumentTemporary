using Core.Models;
using Shared.ViewModels.PasswordChange;
using Shared.ViewModels.User;

namespace Core.Services.Interfaces
{
    public interface IRoleService
    {
        Task Create(Role role);
        Task Update(Role role);
        Task<Role> GetById(Guid roleId);
    }
}
