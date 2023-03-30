using AutoMapper;
using Core.Services.Interfaces;
using DigitalDocumentAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Shared.Enums;
using Shared.ViewModels;
using Shared.ViewModels.Legalization;
using Triplex.Validations;

namespace DigitalDocumentAPI.Controllers
{
    public class LegalizationRequestController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILegalizationRequestService _legalizationRequestService;

        public LegalizationRequestController(IMapper mapper, ILegalizationRequestService legalizationRequestService)
        {
            _legalizationRequestService = legalizationRequestService;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery]LegalizationStatus status)
        {
            IEnumerable<LegalizationQuickView> legalizations = await _legalizationRequestService.GetAll(status);

            return Ok(legalizations);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery]Guid id)
        {
            LegalizationDetails legalization = await _legalizationRequestService.GetById(id);

            return Ok(legalization);
        }

        [HttpGet("get-all-by-user")]
        public async Task<IActionResult> GetByUserId([FromQuery] Guid userId)
        {
            Arguments.NotEmpty(userId, nameof(userId));

            IEnumerable<LegalizationQuickView> legalizationQuickViews = await _legalizationRequestService.GetByUserId(userId);

            return Ok(legalizationQuickViews);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]LegalizationCreation legalizationCreation)
        {
            Arguments.NotNull(legalizationCreation, nameof(legalizationCreation));

            await _legalizationRequestService.Create(legalizationCreation, false);

            return Ok(legalizationCreation.Id);
        }

        [HttpPatch("approve")]
        public async Task<IActionResult> Approve([FromQuery] Guid legalizationId) 
        {
            Arguments.NotEmpty(legalizationId, nameof(legalizationId));

            await _legalizationRequestService.Approve(legalizationId);

            return Ok();
        }

        [HttpPatch("deny")]
        public async Task<IActionResult> Deny([FromQuery] string comment, [FromQuery] Guid legalizationId)
        {
            Arguments.NotEmpty(legalizationId, nameof(legalizationId));

            await _legalizationRequestService.Deny(comment,legalizationId);

            return Ok();
        }

        [HttpPatch("mark-as-paid")]
        public async Task<IActionResult> MaskAsPaid([FromQuery] Guid legalizationId)
        {
            Arguments.NotEmpty(legalizationId, nameof(legalizationId));

            await _legalizationRequestService.MarkAsPaid(legalizationId);

            return Ok();
        }

        [HttpGet("get-dashboard-data")]
        public async Task<IActionResult> GetDashboardData()
        {
            DashboardData dashboardData = await _legalizationRequestService.GetDashboardData();

            return Ok(dashboardData);
        }

        [HttpGet("get-dashboard-data-by-user")]
        public async Task<IActionResult> GetByUserDashboardData([FromQuery] Guid userId)
        {
            DashboardData dashboardData = await _legalizationRequestService.GetByUserDashboardData(userId);

            return Ok(dashboardData);
        }
    }
}
