using Optional;
using Optional.Unsafe;
using Shared.Enums;

namespace DataAccess.Models
{
    public class LegalizationRequestDbModel
    {
        public Guid Id { get; set; }

        public Guid AcademicInstitutionId { get; set; }

        public Guid DocumentTypeId { get; set; }

        public Guid CareerId { get; set; }

        public Guid UserId { get; set; }

        public decimal Amount { get; set; }

        public string DocumentPath { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public LegalizationStatus Status { get; set; }

        public AcademicInstitutionDbModel AcademicInstitution { get; set; } = Option.None<AcademicInstitutionDbModel>().ValueOrDefault();

        public DocumentTypeDbModel DocumentType { get; set; } = Option.None<DocumentTypeDbModel>().ValueOrDefault();

        public CareersDbModel Career { get; set; } = Option.None<CareersDbModel>().ValueOrDefault();

        public UserDbModel User { get; set; } = Option.None<UserDbModel>().ValueOrDefault();
    }
}
