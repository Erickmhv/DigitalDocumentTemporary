using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Optional;
using Optional.Unsafe;
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

        async Task<Option<LegalizationRequestDbModel>> ILegalizationRequestRepository.GetById(int id)
        {

            Option<LegalizationRequestDbModel> legalizationRequestDbModels = (await _context.LegalizationRequests.AsNoTracking()
                                                                                                .Include(legalizationRequest => legalizationRequest.Career)
                                                                                                .Include(legalizationRequest => legalizationRequest.AcademicInstitution)
                                                                                                .Include(legalizationRequest => legalizationRequest.User)
                                                                                                .Include(legalizationRequest => legalizationRequest.DocumentType)
                                                                                                .FirstOrDefaultAsync(legalization => legalization.ExternalId == id)).SomeNotNull()!;

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

        async Task<DashboardData> ILegalizationRequestRepository.GetByUserDashboardData(Guid id)
        {
            DashboardData dashboardData = new();

            dashboardData.AllLegalizationAmount = await _context.LegalizationRequests.AsNoTracking().Where(legalization => legalization.UserId == id).CountAsync();
            dashboardData.TodayApprovedLegalationsAmount = await _context.LegalizationRequests.AsNoTracking().Where(legalization => legalization.CreationDate.Date == DateTime.Now.Date && legalization.Status == LegalizationStatus.Approved && legalization.UserId == id).CountAsync();
            dashboardData.TodayDenyLegalationsAmount = await _context.LegalizationRequests.AsNoTracking().Where(legalization => legalization.CreationDate.Date == DateTime.Now.Date && legalization.Status == LegalizationStatus.Deny && legalization.UserId == id).CountAsync();
            dashboardData.TodayPendingLegalationsAmount = await _context.LegalizationRequests.AsNoTracking().Where(legalization => legalization.CreationDate.Date == DateTime.Now.Date && legalization.Status == LegalizationStatus.Pending && legalization.UserId == id).CountAsync();
            dashboardData.TotalAmountReceivedToday = await _context.LegalizationRequests.AsNoTracking().Where(legalization => legalization.CreationDate.Date == DateTime.Now.Date && legalization.UserId == id).SumAsync(legalization => legalization.Amount);

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

        async Task ILegalizationRequestRepository.UpdateStatus(string comment,LegalizationStatus status, Guid legalizationId)
        {
            Arguments.NotEmpty(legalizationId, nameof(legalizationId));

            LegalizationRequestDbModel legalizationDbModel = (await _context.LegalizationRequests.AsNoTracking().FirstOrDefaultAsync(legalization => legalization.Id == legalizationId))!;

            legalizationDbModel.Status = status;
            legalizationDbModel.Comment = comment;

            _context.LegalizationRequests.Update(legalizationDbModel);
            await _context.SaveChangesAsync();
        }
    }
}
