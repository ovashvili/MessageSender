namespace MessageSender.Domain.Entities;

public class CountryProvider
{
    public int CountryProviderId { get; set; }
    public short Priority { get; set; }
    public bool IsActive { get; set; }

    public string Alpha2Code { get; set; } = null!;
    public Country Country { get; set; } = null!;
    public int ProviderId { get; set; }
    public Provider Provider { get; set; } = null!;
}