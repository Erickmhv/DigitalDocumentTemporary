using Optional;
using Optional.Unsafe;
using Shared.Enums;
using Shared.ViewModels.Dropdowns;

namespace Shared.ViewModels.Legalization
{
    public class LegalizationQuickView
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public LegalizationStatus Status { get; set; }

        public AcademicInstitutionModel AcademicInstitution { get; set; } = Option.None<AcademicInstitutionModel>().ValueOrDefault();

        public DocumentTypeModel DocumentType { get; set; } = Option.None<DocumentTypeModel>().ValueOrDefault();

        public CareerModel Career { get; set; } = Option.None<CareerModel>().ValueOrDefault();

        public UserInformation User { get; set; } = Option.None<UserInformation>().ValueOrDefault();
    }
}
