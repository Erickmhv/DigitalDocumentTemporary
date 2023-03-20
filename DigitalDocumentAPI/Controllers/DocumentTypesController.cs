using AutoMapper;
using Core.Models;
using Core.Services.Interfaces;
using Shared.ViewModels.Dropdowns;

namespace DigitalDocumentAPI.Controllers
{
  public class DocumentTypesController : Helpers.BaseDropDownController<DocumentType, DocumentTypeModel>
  {
    public DocumentTypesController(IBaseDropdownService<DocumentType> brandService, IMapper mapper)
      : base(brandService, mapper)
    {
    }
  }
}
