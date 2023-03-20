namespace Shared.ViewModels.Dropdowns
{
  public abstract class BaseDropdownModel
  {
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
  }
}
