namespace MessageSender.PelekaIntegration.Configurations;

public class PelekaOptions
{
    public const string SectionName = "Peleka";
    public string BaseAddress { get; set; } = null!;
    public string Token { get; set; } = null!;
    public int ProviderId { get; set; }
}