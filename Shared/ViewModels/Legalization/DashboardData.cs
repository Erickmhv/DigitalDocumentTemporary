namespace Shared.ViewModels.Legalization
{
    public class DashboardData
    {
        public decimal AllLegalizationAmount { get; set; }
        public decimal TodayPendingLegalationsAmount { get; set; }
        public decimal TodayDenyLegalationsAmount { get; set; }
        public decimal TodayApprovedLegalationsAmount { get; set; }
        public decimal TotalAmountReceivedToday { get; set; }
    }
}
