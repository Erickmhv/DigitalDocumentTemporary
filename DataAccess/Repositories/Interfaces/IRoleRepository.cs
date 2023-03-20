using DataAccess.Models;
using Optional;
using Shared.Enums;

namespace DataAccess.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task Create(RoleDbModel role);
        Task Update(RoleDbModel role);
        Task<Option<RoleDbModel?>> GetById(Guid id);
    }
}
