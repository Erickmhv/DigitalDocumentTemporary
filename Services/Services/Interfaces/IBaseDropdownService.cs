using Core.Models;

namespace Core.Services.Interfaces
{
    public interface IBaseDropdownService<T>
      where T : BaseDropdown
    {
        Task<IEnumerable<T>> GetAll();
    }
}
