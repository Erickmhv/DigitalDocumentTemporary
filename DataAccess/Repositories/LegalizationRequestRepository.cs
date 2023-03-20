using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Optional;
using Shared.Enums;
using Shared.ViewModels.Legalization;
using Triplex.Validations;

namespace DataAccess.Repositories
{
    public class LegalizationRequestRepository : ILegalizationRequestRepository
    {
        private readonly SqlServerContext _context;

        public LegalizationRequestRepository(SqlServerContext context)
        {
            _context = context;
        }

        async Task ILegalizationRequestRepository.Create(LegalizationRequestDbModel legalizationDbModel)
        {
            Arguments.NotNull(legalizationDbModel, nameof(legalizationDbModel));

            await _context.LegalizationRequests.AddAsync(legalizationDbModel);
            await _context.SaveChangesAsync();
        }

        async Task<IEnumerable<LegalizationRequestDbModel>> ILegalizationRequestRepository.GetAll(LegalizationStatus status)
        {
            IEnumerable<LegalizationRequestDbModel> legalizationRequestDbModels = await _context.LegalizationRequests.AsNoTracking()
                                                                                                .Include(legalizationRequest => legalizationRequest.Career)
                                                                                                .Include(legalizationRequest => legalizationRequest.AcademicInstitution)
                                                                                                .Include(legalizationRequest => legalizationRequest.User)
                                                                                                .Include(legalizationRequest => legalizationRequest.DocumentType)
                                                                                                .Where(legalizationStatus => legalizationStatus.Status == status)
                                                                                                .ToListAsync();

            return legalizationRequestDbModels;
        }

        async Task<Option<LegalizationRequestDbModel>> ILegalizationRequestRepository.GetById(Guid id)
        {
            Arguments.NotEmpty(id, nameof(id));

            Option<LegalizationRequestDbModel> legalizationRequestDbModels = (await _context.LegalizationRequests.AsNoTracking()
                                                                                                .Include(legalizationRequest => legalizationRequest.Career)
                                                                                                .Include(legalizationRequest => legalizationRequest.AcademicInstitution)
                                                                                                .Include(legalizationRequest => legalizationRequest.User)
                                                                                                .Include(legalizationRequest => legalizationRequest.DocumentType)
                                                                                                .FirstOrDefaultAsync(legalization => legalization.Id == id)).SomeNotNull()!;

            return legalizationRequestDbModels;
        }

        async Task<IEnumerable<LegalizationRequestDbModel>> ILegalizationRequestRepository.GetByUserId(Guid userId)
        {
            Arguments.NotEmpty(userId, nameof(userId));

            IEnumerable<LegalizationRequestDbModel> legalizationRequestDbModels = await _context.LegalizationRequests.AsNoTracking()
                                                                                                .Include(legalizationRequest => legalizationRequest.Career)
                                                                                                .Include(legalizationRequest => legalizationRequest.AcademicInstitution)
                                                                                                .Include(legalizationRequest => legalizationRequest.User)
                                                                                                .Include(legalizationRequest => legalizationRequest.DocumentType)
                                                                                                .Where(legalizationRequest => legalizationRequest.UserId == userId)
                                                                                                .ToListAsync();

            return legalizationRequestDbModels;
        }
        async Task<DashboardData> ILegalizationRequestRepository.GetDashBoardData()
        {
            DashboardData dashboardData = new();

            dashboardData.AllLegalizationAmount = await _context.LegalizationRequests.AsNoTracking().CountAsync();
            dashboardData.TodayApprovedLegalationsAmount = await _context.LegalizationRequests.AsNoTracking().Where(legalization => legalization.CreationDate.Date == DateTime.Now.Date && legalization.Status == LegalizationStatus.Approved).CountAsync();
            dashboardData.TodayDenyLegalationsAmount = await _context.LegalizationRequests.AsNoTracking().Where(legalization => legalization.CreationDate.Date == DateTime.Now.Date && legalization.Status == LegalizationStatus.Deny).CountAsync();
            dashboardData.TodayPendingLegalationsAmount = await _context.LegalizationRequests.AsNoTracking().Where(legalization => legalization.CreationDate.Date == DateTime.Now.Date && legalization.Status == LegalizationStatus.Pending).CountAsync(); ;
            dashboardData.TotalAmountReceivedToday = await _context.LegalizationRequests.AsNoTracking().Where(legalization => legalization.CreationDate.Date == DateTime.Now.Date).SumAsync(legalization => legalization.Amount);

            return dashboardData;
        }

        async Task ILegalizationRequestRepository.UpdateStatus(LegalizationStatus status, Guid legalizationId)
        {
            Arguments.NotEmpty(legalizationId, nameof(legalizationId));

            LegalizationRequestDbModel legalizationDbModel = (await _context.LegalizationRequests.AsNoTracking().FirstOrDefaultAsync(legalization => legalization.Id == legalizationId))!;

            legalizationDbModel.Status = status;

            _context.LegalizationRequests.Update(legalizationDbModel);
            await _context.SaveChangesAsync();
        }
    }
}
