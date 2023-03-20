using AutoMapper;
using Core.Models;
using Core.Services.Interfaces;
using Shared.ViewModels.Dropdowns;

namespace DigitalDocumentAPI.Controllers
{
  public class AcademicInstitutionController : Helpers.BaseDropDownController<AcademicInstitution, AcademicInstitutionModel>
  {
    public AcademicInstitutionController(IBaseDropdownService<AcademicInstitution> brandService, IMapper mapper)
      : base(brandService, mapper)
    {
    }
  }
}
