namespace MessageSender.NexmoIntegration.Configurations;

public class NexmoOptions
{
    public const string SectionName = "Nexmo";
    public string BaseAddress { get; set; } = null!;
    public string ApiKey { get; set; } = null!;
    public string ApiSecret { get; set; } = null!;
    public int ProviderId { get; set; }
}