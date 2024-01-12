namespace MessageSender.Domain.Entities;

public class Provider
{
    public int ProviderId { get; set; }
    public string Name { get; set; } = null!;
    public short Priority { get; set; }
    public string Config { get; set; } = null!;
    public bool IsGlobal { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<MessageDelivery> MessageDeliveries { get; set; } = new List<MessageDelivery>();
    public virtual ICollection<CountryProvider> CountryProviders { get; set; } = new List<CountryProvider>();

}