using AutoMapper;
using Core.Models;
using Core.Services.Interfaces;
using Shared.ViewModels.Dropdowns;

namespace DigitalDocumentAPI.Controllers
{
  public class CareersController : Helpers.BaseDropDownController<Career, CareerModel>
  {
    public CareersController(IBaseDropdownService<Career> brandService, IMapper mapper)
      : base(brandService, mapper)
    {
    }
  }
}
