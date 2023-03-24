namespace Shared.ViewModels
{
  public class UserInformation
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty;

        public string Identification { get; set; } = string.Empty;

        public int IdentificationType { get; set; }

        public string Phone { get; set; } = string.Empty;

        public DateTime Birthdate { get; set; }

        public string City { get; set; } = string.Empty;

        public string Addresss { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
