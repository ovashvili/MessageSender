namespace MessageSender.Domain.Entities;

public class Country
{
    public string Alpha2Code { get; set; } = null!;
    public short DialCode { get; set; }
    public string AreaCode { get; set; } = null!;
    public bool IsActive { get; set; }
    public virtual ICollection<CountryProvider> CountryProviders { get; } = new List<CountryProvider>();
}