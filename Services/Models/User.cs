using Shared.Helpers;

namespace Core.Models
{
    public class User
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

        public string Password { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public static string EncryptPassword(string password)
        {
            string encryptedPassword = Encrypt.EncryptString(password);

            return encryptedPassword;
        }

        public static string DecryptPassword(string password)
        {
            string decryptedPassword = Encrypt.DecryptString(password);

            return decryptedPassword;
        }
    }
}
