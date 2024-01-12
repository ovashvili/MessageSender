namespace MessageSender.MagtiIntegration.Configurations;

public class MagtiOptions
{
    public const string SectionName = "Magti";
    public string BaseAddress { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int ProviderId { get; set; }
}