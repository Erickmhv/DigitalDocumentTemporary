using AutoMapper;
using Core.Models;
using Core.Services.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using GroupDocs.Watermark;
using GroupDocs.Watermark.Options.Pdf;
using GroupDocs.Watermark.Watermarks;
using Optional;
using Optional.Unsafe;
using Shared.Enums;
using Shared.Interfaces;
using Shared.ViewModels;
using Shared.ViewModels.Legalization;
using System.Net.Http.Json;
using Triplex.Validations;

namespace Core.Services
{
    public class LegalizationRequestService : ILegalizationRequestService
    {
        private readonly ILegalizationRequestRepository _legalizationRequestRepo;
        private readonly IUserService _userService;
        private readonly IFileService _fileService;
        private readonly ISMTPService _smtpService;
        private readonly IMapper _mapper;
        private const string _documentName = "Document.pdf";
        private const string _documentMarkedName = "DocumentMarked.pdf";

        public LegalizationRequestService(ILegalizationRequestRepository legalizationRequestRepository, IUserService userService, IMapper mapper, IFileService fileService, ISMTPService smtpService)
        {
            _legalizationRequestRepo = legalizationRequestRepository;
            _userService = userService;
            _mapper = mapper;
            _fileService = fileService;
            _smtpService = smtpService;
        }

        async Task<Guid> ILegalizationRequestService.Create(LegalizationCreation legalization, bool IsByExposed)
        {
            Arguments.NotNull(legalization, nameof(legalization));

            if(legalization.Id == Guid.Empty || legalization.Id == Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"))
            legalization.Id = Guid.NewGuid();

            string documentPath = await _fileService.SaveFileAsync(legalization.Base64Document, _documentName, legalization.Id);
            legalization.DocumentPath = documentPath;

            User? user = null;

            try
            {
                user = await _userService.GetByEmail(legalization.StudentEmail);
                legalization.UserId = user.Id;
            }
            catch (Exception)
            {

            }

            if (user == null)
                try
                {
                    User usuario = new User()
                    {
                        Id = legalization.UserId,
                        Name = legalization.StudentName,
                        Lastname = legalization.StudentLastName,
                        Phone = legalization.StudentPhone,
                        Email = legalization.StudentEmail,
                        Identification = legalization.StudentIdentification,
                        IdentificationType = legalization.StudentIdentificationType,
                        RoleId = Guid.Parse("B6C977E9-09DA-4454-94B1-58C22A7DA7AB"),
                    };
                    await _userService.Create(usuario);

                    user = await _userService.GetByEmail(legalization.StudentEmail);
                    legalization.UserId = user.Id;

                }
                catch (Exception)
                {

                }

            LegalizationRequestDbModel legalizationDbModel = _mapper.Map<LegalizationRequestDbModel>(legalization);
            legalizationDbModel.IsByExposed = IsByExposed;

            if (legalizationDbModel.IsByExposed)
            {
                State.IsFalse(_legalizationRequestRepo.GetById(legalization.ExternalId).Result.HasValue, "Ya existe una solicitud con este ExternalID");
            }


            await _legalizationRequestRepo.Create(legalizationDbModel);

            LegalizationDetails details = _mapper.Map<LegalizationDetails>(legalizationDbModel);


            user = await _userService.GetById(legalization.UserId);

            UserInformation userInfo = _mapper.Map<UserInformation>(user);

            details.User = userInfo;

            try
            {
                await _smtpService.SendMail(details, LegalizationStatus.Pending);
            }
            catch (Exception)
            {

            }

            return legalization.Id;
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

            legalizationDbModel.DocumentPath = legalizationDbModel.Status == LegalizationStatus.Approved ? legalizationDbModelOption.ValueOrFailure().DocumentPath.Replace(_documentName, _documentMarkedName) : legalizationDbModelOption.ValueOrFailure().DocumentPath;

            string fileBase64 = await _fileService.GetImageBase64StringAsync(legalizationDbModel.DocumentPath);

            LegalizationDetails details = _mapper.Map<LegalizationDetails>(legalizationDbModel);
            details.Base64String = fileBase64;

            return details;
        }

        async Task<LegalizationDetails> ILegalizationRequestService.GetById(int legalizationId)
        {           

            Option<LegalizationRequestDbModel> legalizationDbModelOption = await _legalizationRequestRepo.GetById(legalizationId);

            State.IsTrue(legalizationDbModelOption.HasValue, "Esta legalización no está registrada en el sistema");

            LegalizationRequestDbModel legalizationDbModel = legalizationDbModelOption.ValueOrFailure()!;

            legalizationDbModel.DocumentPath = legalizationDbModel.Status == LegalizationStatus.Approved ? legalizationDbModelOption.ValueOrFailure().DocumentPath.Replace(_documentName, _documentMarkedName) : legalizationDbModelOption.ValueOrFailure().DocumentPath;

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
            //State.IsTrue(legalizationDbModelOption.ValueOrFailure().Status == LegalizationStatus.Pending, "La solicitud debe estar pendiente para ser aprobada");

            await _legalizationRequestRepo.UpdateStatus(LegalizationStatus.Approved, legalizationDbModelOption.ValueOrFailure().Id);

            PdfLoadOptions loadOptions = new PdfLoadOptions();
            using (Watermarker watermarker = new Watermarker(legalizationDbModelOption.ValueOrFailure().DocumentPath, loadOptions))
            {
                ImageWatermark imageWatermark = new ImageWatermark("Logo legalizacion.png")
                {
                    Opacity = 0.5,
                    X = 50,
                    Y = 200
                };
                watermarker.Add(imageWatermark);

                watermarker.Save(legalizationDbModelOption.ValueOrFailure().DocumentPath.Replace(_documentName, _documentMarkedName));
            }

            LegalizationRequestDbModel legalizationDbModel = legalizationDbModelOption.ValueOrFailure()!;
            LegalizationDetails details = _mapper.Map<LegalizationDetails>(legalizationDbModel);

            try
            {
                if (legalizationDbModel.IsByExposed)
                {
                    await SendDocument(legalizationDbModel,1);
                }
                await _smtpService.SendMail(details, LegalizationStatus.Approved);
            }
            catch (Exception)
            {

            }


        }

        async Task ILegalizationRequestService.Deny(string comment, Guid legalizationId)
        {
            Arguments.NotEmpty(legalizationId, nameof(legalizationId));

            Option<LegalizationRequestDbModel> legalizationDbModelOption = await _legalizationRequestRepo.GetById(legalizationId);

            State.IsTrue(legalizationDbModelOption.HasValue, "Esta legalización no está registrada en el sistema");
            //State.IsTrue(legalizationDbModelOption.ValueOrFailure().Status == LegalizationStatus.Pending, "La solicitud debe estar pendiente para ser rechazada");

            await _legalizationRequestRepo.UpdateStatus(comment, LegalizationStatus.Deny, legalizationDbModelOption.ValueOrFailure().Id);

            LegalizationRequestDbModel legalizationDbModel = legalizationDbModelOption.ValueOrFailure()!;
            LegalizationDetails details = _mapper.Map<LegalizationDetails>(legalizationDbModel);

            try
            {
                if (legalizationDbModel.IsByExposed)
                {
                    await SendDocument(legalizationDbModel, 0);
                }
                await _smtpService.SendMail(details, LegalizationStatus.Deny);
            }
            catch (Exception)
            {

            }

        }

        async Task ILegalizationRequestService.MarkAsPaid(Guid legalizationId)
        {
            Arguments.NotEmpty(legalizationId, nameof(legalizationId));

            Option<LegalizationRequestDbModel> legalizationDbModelOption = await _legalizationRequestRepo.GetById(legalizationId);

            State.IsTrue(legalizationDbModelOption.HasValue, "Esta legalización no está registrada en el sistema");

            await _legalizationRequestRepo.UpdateStatus(LegalizationStatus.Paid, legalizationDbModelOption.ValueOrFailure().Id);

            LegalizationRequestDbModel legalizationDbModel = legalizationDbModelOption.ValueOrFailure()!;
            LegalizationDetails details = _mapper.Map<LegalizationDetails>(legalizationDbModel);

            try
            {
                await _smtpService.SendMail(details, LegalizationStatus.Paid);
            }
            catch (Exception)
            {

            }

        }

        async Task<DashboardData> ILegalizationRequestService.GetDashboardData()
        {
            DashboardData dashboardData = await _legalizationRequestRepo.GetDashBoardData();

            return dashboardData;
        }

        async Task<DashboardData> ILegalizationRequestService.GetByUserDashboardData(Guid userId)
        {
            DashboardData dashboardData = await _legalizationRequestRepo.GetByUserDashboardData(userId);

            return dashboardData;
        }

        private async Task SendDocument(LegalizationRequestDbModel legalizationRequest, int estado)
        {
            using (var httpClient = new HttpClient())
            {
                string documentPath = legalizationRequest.DocumentPath.Replace(_documentName, _documentMarkedName);
                string fileBase64 = await _fileService.GetImageBase64StringAsync(documentPath);
                object requestBody = new
                {
                    ID_Solicitud = legalizationRequest.ExternalId,
                    Base64 = fileBase64,
                    Estado = estado,
                    Comentario = legalizationRequest.Comment ?? "Aprobada"
                };

                await httpClient.PutAsJsonAsync("http://www.softuniapi.somee.com/api/LegalizacionDocumentos", requestBody);
                
            }
        }
    }
}
