namespace MessageSender.Domain.Entities;

public class Client
{
    public Guid ClientId { get; set; }
    public Guid Secret { get; set; }
    public string Config { get; set; } = null!;
    public bool IsActive { get; set; }

    public virtual ICollection<Sms> Smses { get; set; } = new List<Sms>();
}