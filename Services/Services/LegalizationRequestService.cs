using AutoMapper;
using Core.Models;
using Core.Services.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Optional;
using Optional.Unsafe;
using Shared.Enums;
using Shared.Interfaces;
using Shared.ViewModels.Legalization;
using Shared.ViewModels.PasswordChange;
using Shared.ViewModels.User;
using System.Text.RegularExpressions;
using Triplex.Validations;

namespace Core.Services
{
    public class LegalizationRequestService : ILegalizationRequestService
    {
        private readonly ILegalizationRequestRepository _legalizationRequestRepo;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private const string _documentName = "Document.pdf";

        public LegalizationRequestService(ILegalizationRequestRepository legalizationRequestRepository, IMapper mapper, IFileService fileService)
        {
            _legalizationRequestRepo = legalizationRequestRepository;
            _mapper = mapper;
            _fileService = fileService;
        }

        async Task ILegalizationRequestService.Create(LegalizationCreation legalization)
        {
            Arguments.NotNull(legalization, nameof(legalization));

            legalization.Id = Guid.NewGuid();

            string documentPath = await _fileService.SaveFileAsync(legalization.Base64Document, _documentName, legalization.Id);
            legalization.DocumentPath = documentPath;

            LegalizationRequestDbModel legalizationDbModel = _mapper.Map<LegalizationRequestDbModel>(legalization);
            await _legalizationRequestRepo.Create(legalizationDbModel);
        }

        async Task<IEnumerable<LegalizationQuickView>> ILegalizationRequestService.GetAll(LegalizationStatus status)
        {
            IEnumerable<LegalizationRequestDbModel> legalizations = await _legalizationRequestRepo.GetAll(status);

            IEnumerable<LegalizationQuickView> legalizationsModels = _mapper.Map<IEnumerable<LegalizationQuickView>>(legalizations);

            return legalizationsModels;
        }

        async Task<LegalizationDetails> ILegalizationRequestService.GetById(Guid legalizationId)
        {
            Arguments.NotEmpty(legalizationId, nameof(legalizationId));

            Option<LegalizationRequestDbModel> legalizationDbModelOption = await _legalizationRequestRepo.GetById(legalizationId);

            State.IsTrue(legalizationDbModelOption.HasValue, "Esta legalización no está registrada en el sistema");

            LegalizationRequestDbModel legalizationDbModel = legalizationDbModelOption.ValueOrFailure()!;

            string fileBase64 = await _fileService.GetImageBase64StringAsync(legalizationDbModel.DocumentPath);

            LegalizationDetails details = _mapper.Map<LegalizationDetails>(legalizationDbModel);
            details.Base64String = fileBase64;

            return details;
        }

        async Task<IEnumerable<LegalizationQuickView>> ILegalizationRequestService.GetByUserId(Guid userId)
        {
            Arguments.NotEmpty(userId, nameof(userId));

            IEnumerable<LegalizationRequestDbModel> legalizations = await _legalizationRequestRepo.GetByUserId(userId);

            IEnumerable<LegalizationQuickView> legalizationsModels = _mapper.Map<IEnumerable<LegalizationQuickView>>(legalizations);

            return legalizationsModels;
        }

        async Task ILegalizationRequestService.Approve(Guid legalizationId)
        {
            Arguments.NotEmpty(legalizationId, nameof(legalizationId));

            Option<LegalizationRequestDbModel> legalizationDbModelOption = await _legalizationRequestRepo.GetById(legalizationId);

            State.IsTrue(legalizationDbModelOption.HasValue, "Esta legalización no está registrada en el sistema");
            State.IsTrue(legalizationDbModelOption.ValueOrFailure().Status == LegalizationStatus.Pending, "La solicitud debe estar pendiente para ser aprobada");

            await _legalizationRequestRepo.UpdateStatus(LegalizationStatus.Approved, legalizationDbModelOption.ValueOrFailure().Id);
        }

        async Task ILegalizationRequestService.Deny(Guid legalizationId)
        {
            Arguments.NotEmpty(legalizationId, nameof(legalizationId));

            Option<LegalizationRequestDbModel> legalizationDbModelOption = await _legalizationRequestRepo.GetById(legalizationId);

            State.IsTrue(legalizationDbModelOption.HasValue, "Esta legalización no está registrada en el sistema");
            State.IsTrue(legalizationDbModelOption.ValueOrFailure().Status == LegalizationStatus.Pending, "La solicitud debe estar pendiente para ser rechazada");

            await _legalizationRequestRepo.UpdateStatus(LegalizationStatus.Deny, legalizationDbModelOption.ValueOrFailure().Id);
        }

        async Task<DashboardData> ILegalizationRequestService.GetDashboardData()
        {
            DashboardData dashboardData = await _legalizationRequestRepo.GetDashBoardData();

            return dashboardData;
        }
    }
}
