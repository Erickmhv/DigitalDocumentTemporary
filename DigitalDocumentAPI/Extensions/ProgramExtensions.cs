using AutoMapper;
using Core.Models;
using Core.Services;
using Core.Services.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Shared.Helpers;
using Shared.Interfaces;
using Utils;

namespace DigitalDocumentAPI.Extensions
{
    public static class ProgramExtensions
    {
        public static void RegisterAppDependencies(this IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterServices(services);
        }
        public static void RegisterMappingProfiles(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILegalizationRequestService, LegalizationRequestService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ISMTPService, SMTPService>();
            services.AddScoped(typeof(IBaseDropdownService<BaseDropdown>), typeof(BaseDropDownService<BaseDropdown, BaseDropdownDbModel>));
            services.AddScoped(typeof(IBaseDropdownService<Career>), typeof(BaseDropDownService<Career, CareersDbModel>));
            services.AddScoped(typeof(IBaseDropdownService<DocumentType>), typeof(BaseDropDownService<DocumentType, DocumentTypeDbModel>));
            services.AddScoped(typeof(IBaseDropdownService<AcademicInstitution>), typeof(BaseDropDownService<AcademicInstitution, AcademicInstitutionDbModel>));
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordChangeRepository, PasswordChangeRepository>();
            services.AddScoped<ILegalizationRequestRepository, LegalizationRequestRepository>();
            services.AddScoped(typeof(IBaseDropdownRepository<>), typeof(BaseDropdownRepository<>));
        }
    }
}
