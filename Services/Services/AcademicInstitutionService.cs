using AutoMapper;
using Core.Models;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;

namespace Core.Services
{
  public class AcademicInstitutionService : BaseDropDownService<AcademicInstitution, AcademicInstitutionDbModel>
  {
    public AcademicInstitutionService(IBaseDropdownRepository<AcademicInstitutionDbModel> baseDropdownRepository, IMapper mapper)
      : base(baseDropdownRepository, mapper)
    {
    }
  }
}
