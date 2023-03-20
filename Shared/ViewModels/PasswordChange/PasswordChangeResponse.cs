namespace Shared.ViewModels.PasswordChange
{
    public class PasswordChangeResponse
    {
        public Guid Id { get; set; }
        public string Password { get; set; } = string.Empty;
        public string PasswordConfirmation { get; set; } = string.Empty;
    }
}
