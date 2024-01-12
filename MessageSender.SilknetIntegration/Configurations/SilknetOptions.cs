namespace MessageSender.SilknetIntegration.Configurations;

public class SilknetOptions
{
    public const string SectionName = "Silknet";
    public string BaseAddress { get; set; } = null!;
    public int ProviderId { get; set; }
}