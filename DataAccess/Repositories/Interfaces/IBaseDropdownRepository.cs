using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces
{
  public interface IBaseDropdownRepository<T> where T : BaseDropdownDbModel
  {
    Task<IEnumerable<T>> GetAll();
  }
}
