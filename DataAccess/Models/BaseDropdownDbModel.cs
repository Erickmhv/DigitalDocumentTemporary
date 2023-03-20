using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
  public abstract class BaseDropdownDbModel
  {
    [Required]
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
  }
}
