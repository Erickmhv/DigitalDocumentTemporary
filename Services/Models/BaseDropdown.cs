namespace Core.Models
{
  public abstract class BaseDropdown
  {
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
  }
}
