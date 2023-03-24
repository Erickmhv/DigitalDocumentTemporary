using AutoMapper;
using Core.Models;
using DataAccess.Models;
using Shared.Helpers;
using Shared.ViewModels;
using Shared.ViewModels.Dropdowns;
using Shared.ViewModels.Legalization;
using Shared.ViewModels.PasswordChange;

namespace Utils
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PasswordChangeDbModel, PasswordChangeModel>().ReverseMap();

            CreateMap<User, UserInformation>();
            CreateMap<UserDbModel, UserInformation>();

            CreateMap<UserModel, User>().ForMember(user => user.Password, memberConfiguration => memberConfiguration.MapFrom(user => User.EncryptPassword(user.Password)));
            CreateMap<User, UserModel>().ForMember(user => user.Password, memberConfiguration => memberConfiguration.MapFrom(user => User.DecryptPassword(user.Password)));

            CreateMap<UserDbModel, User>().ReverseMap();

            CreateMap<LoginModel, User>().ForMember(user => user.Password, memberConfiguration => memberConfiguration.MapFrom(user => User.EncryptPassword(user.Password)));
            CreateMap<User, LoginModel>().ForMember(user => user.Password, memberConfiguration => memberConfiguration.MapFrom(user => User.DecryptPassword(user.Password)));

            CreateMap<AcademicInstitution, AcademicInstitutionDbModel>().ReverseMap();
            CreateMap<AcademicInstitution, AcademicInstitutionModel>().ReverseMap();
            CreateMap<AcademicInstitutionDbModel, AcademicInstitutionModel>().ReverseMap();

            CreateMap<Career, CareersDbModel>().ReverseMap();
            CreateMap<CareerModel, CareersDbModel>().ReverseMap();
            CreateMap<Career, CareerModel>().ReverseMap();

            CreateMap<DocumentType, DocumentTypeDbModel>().ReverseMap();
            CreateMap<DocumentTypeModel, DocumentTypeDbModel>().ReverseMap();
            CreateMap<DocumentType, DocumentTypeModel>().ReverseMap();

            CreateMap<LegalizationRequestDbModel, LegalizationCreation>().ReverseMap();
            CreateMap<LegalizationRequestDbModel, LegalizationQuickView>().ReverseMap();
            CreateMap<LegalizationRequestDbModel, LegalizationDetails>().ReverseMap();

            CreateMap<LegalizationRequestDbModel, SMTPService>().ReverseMap();

            CreateMap<Role, RoleDbModel>().ReverseMap();
            CreateMap<RoleModel, Role>().ReverseMap();
        }
    }
}
