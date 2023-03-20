using AutoMapper;
using Core.Models;
using Core.Services.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;

namespace Core.Services
{
  public class BaseDropDownService<T, J> : IBaseDropdownService<T>
    where T : BaseDropdown
    where J : BaseDropdownDbModel
  {
    private readonly IBaseDropdownRepository<J> _baseDropdownRepository;
    private readonly IMapper _mapper;

    public BaseDropDownService(IBaseDropdownRepository<J> baseDropdownRepository, IMapper mapper)
    {
      _mapper = mapper;
      _baseDropdownRepository = baseDropdownRepository;
    }

    async Task<IEnumerable<T>> IBaseDropdownService<T>.GetAll()
    {
      IEnumerable<J> models = await _baseDropdownRepository.GetAll();
      IEnumerable<T> result = _mapper.Map<IEnumerable<T>>(models);

      

      return result;
    }
  }
}
