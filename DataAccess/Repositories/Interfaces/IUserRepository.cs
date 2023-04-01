using DataAccess.Models;
using Optional;
using Shared.Enums;

namespace DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Option<UserDbModel?>> Create(UserDbModel user);
        Task Update(UserDbModel user);
        Task<bool> ValidateIfExsits(string identification, IdentificationType identificationType, string email, Guid id);
        Task<Option<UserDbModel?>> Login(UserDbModel user);
        Task<Option<UserDbModel?>> GetByEmail(string email);
        Task<Option<UserDbModel?>> GetById(Guid id);
        Task<Option<UserDbModel?>> ValidateUserPasswordById(Guid userId, string oldPassword);
    }
}
