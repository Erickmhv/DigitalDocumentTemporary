using Optional;
using Optional.Unsafe;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class PasswordChangeDbModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        public Guid UserId { get; set; }

        public UserDbModel User { get; set; } = Option.None<UserDbModel>().ValueOrDefault();
    }
}
