using Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class UserDbModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(80)]
        public string Lastname { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Identification { get; set; } = string.Empty;

        [Required]
        public IdentificationType IdentificationType { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Addresss { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Password { get; set; } = string.Empty;
        

        [Required]
        public Guid RoleId { get; set; }

        public RoleDbModel Role { get;set; }

        public void Map(UserDbModel userDbModel)
        {
            this.Name = userDbModel.Name;
            this.Lastname = userDbModel.Lastname;
            this.Identification = userDbModel.Identification;
            this.IdentificationType = userDbModel.IdentificationType;
            this.Addresss = userDbModel.Addresss;
            this.Birthdate = userDbModel.Birthdate;
            this.City = userDbModel.City;
            this.Phone = userDbModel.Phone;
            this.RoleId = userDbModel.RoleId;
        }
    }
}
