using Core.Models;
using Shared.ViewModels.PasswordChange;
using Shared.ViewModels.User;

namespace Core.Services.Interfaces
{
    public interface IUserService
    {
        Task Create(User user);
        Task Update(User user);
        Task<User> GetById(Guid userId);
        Task<User> GetByEmail(string studentEmail);
        Task<User> Login(User user);
        Task<Guid> CreateChangeRequest(string userEmail);
        Task ValidateChangeRequest(Guid changeRequestId);
        Task ChangePassword(PasswordChangeResponse passwordChange);
        Task UpdatePassword(UpdatePassword passwordChange, Guid userId);
    }
}
