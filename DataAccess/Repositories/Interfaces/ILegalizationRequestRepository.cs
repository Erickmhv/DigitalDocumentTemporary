using DataAccess.Models;
using Optional;
using Shared.Enums;
using Shared.ViewModels.Legalization;

namespace DataAccess.Repositories.Interfaces
{
    public interface ILegalizationRequestRepository
    {
        Task Create(LegalizationRequestDbModel legalizationRequest);
        Task<Option<LegalizationRequestDbModel>> GetById(Guid id);
        Task<Option<LegalizationRequestDbModel>> GetById(int id);
        Task<IEnumerable<LegalizationRequestDbModel>> GetByUserId(Guid id);
        Task<IEnumerable<LegalizationRequestDbModel>> GetAll(LegalizationStatus status);
        Task UpdateStatus(LegalizationStatus status, Guid legalizationId);
        Task UpdateStatus(string comment,LegalizationStatus status, Guid legalizationId);
        Task<DashboardData> GetDashBoardData();

        Task<DashboardData> GetByUserDashboardData(Guid id);
    }
}
