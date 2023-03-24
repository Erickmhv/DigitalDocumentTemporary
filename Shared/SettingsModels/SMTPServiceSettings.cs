namespace Shared.SettingsModels
{
    public class SMTPServiceSettings
    {
        public string SMTPClient { get; set; } = string.Empty;
        public string Port { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
