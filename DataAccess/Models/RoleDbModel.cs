using Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class RoleDbModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;
       
        [Required]
        public RoleType RoleType { get; set; }

        public void Map(RoleDbModel roleDbModel)
        {
            this.Name = roleDbModel.Name;
            this.RoleType = roleDbModel.RoleType;
        }
    }
}
