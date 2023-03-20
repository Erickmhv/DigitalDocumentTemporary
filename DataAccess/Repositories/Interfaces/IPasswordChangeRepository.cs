using DataAccess.Models;
using Optional;
using Shared.Enums;

namespace DataAccess.Repositories.Interfaces
{
  public interface IPasswordChangeRepository
  {
    Task Create(PasswordChangeDbModel passwordChangeRequest);

    Task<Option<PasswordChangeDbModel>> ValidateIfExsits(Guid id);
  }
}
