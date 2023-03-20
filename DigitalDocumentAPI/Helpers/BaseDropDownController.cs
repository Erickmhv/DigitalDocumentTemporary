using AutoMapper;
using Core.Models;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels.Dropdowns;

namespace DigitalDocumentAPI.Helpers
{
  [ApiController]
  [Route("[controller]")]
  public abstract class BaseDropDownController<T, J> : Controller
    where T : BaseDropdown
    where J : BaseDropdownModel
  {
    private readonly IBaseDropdownService<T> _baseService;
    private readonly IMapper _mapper;
    public BaseDropDownController(IBaseDropdownService<T> baseService, IMapper mapper)
    {
      _baseService = baseService;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      IEnumerable<T> allEntries = await _baseService.GetAll();
      IEnumerable<J> entriesModels = _mapper.Map<IEnumerable<J>>(allEntries);

      return Ok(entriesModels);
    }
  }
}
