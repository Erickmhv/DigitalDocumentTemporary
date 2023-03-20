using Shared.Enums;
using Shared.ViewModels.Legalization;

namespace Core.Services.Interfaces
{
    public interface ILegalizationRequestService
    {
        Task Create(LegalizationCreation legalization);
        Task<IEnumerable<LegalizationQuickView>> GetAll(LegalizationStatus status);
        Task<LegalizationDetails> GetById(Guid legalization);
        Task<IEnumerable<LegalizationQuickView>> GetByUserId(Guid userId);
        Task Approve(Guid legalizationId);
        Task Deny(Guid legalizationId);
        Task<DashboardData> GetDashboardData();
        Task<DashboardData> GetByUserDashboardData(Guid id);

    }
}
