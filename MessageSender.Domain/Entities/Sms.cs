namespace MessageSender.Domain.Entities;

public class Sms
{
    public long SmsId { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string? Message { get; set; }
    public DateTime CreateDate { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; set; } = null!;
    public virtual ICollection<MessageDelivery> MessageDeliveries { get; set; } = new List<MessageDelivery>();
}