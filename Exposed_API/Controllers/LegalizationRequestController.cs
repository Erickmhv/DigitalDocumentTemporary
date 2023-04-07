using AutoMapper;
using Core.Services.Interfaces;
using Exposed_API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Shared.Enums;
using Shared.ViewModels.Legalization;
using Triplex.Validations;

namespace Exposed_API.Controllers
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

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            LegalizationDetails legalization = await _legalizationRequestService.GetById(id);

            return Ok(legalization);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]LegalizationCreation legalizationCreation)
        {
            Arguments.NotNull(legalizationCreation, nameof(legalizationCreation));

            await _legalizationRequestService.Create(legalizationCreation, true);

            return Ok(new { Id = legalizationCreation.Id, Estatus = true });
        }
    }
}
