using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels.Legalization
{
    public class LegalizationCreation
    {
        public Guid Id { get; set; }

        public Guid AcademicInstitutionId { get; set; }

        public Guid DocumentTypeId { get; set; }

        public Guid CareerId { get; set; }

        public Guid UserId { get; set; }

        public decimal Amount { get; set; }

        public string Base64Document { get; set; } = string.Empty;
        public string DocumentPath { get; set; } = string.Empty;

        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
