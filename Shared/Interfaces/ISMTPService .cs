using Shared.Enums;
using Shared.ViewModels.Legalization;

namespace Shared.Interfaces
{
    public interface ISMTPService
    {
        Task SendMail(LegalizationDetails legalizationDetails, LegalizationStatus legalizationStatus);
        
    }
}
