namespace Shared.ViewModels.PasswordChange
{
    public class PasswordChangeModel
    {
        public Guid Id { get; set; }

        public DateTime ExpireDate { get; set; }

        public Guid UserId { get; set; }
    }
}
