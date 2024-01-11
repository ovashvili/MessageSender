using MessageSender.Domain.Enums;

namespace MessageSender.Domain.Entities;

public class MessageDelivery
{
    public long MessageDeliveryId { get; set; }
    public MessageDeliveryStatus Status { get; set; }
    public string? StatusNote { get; set; }
    public string? ProviderMessageId { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime ModifyDate { get; set; }

    public long? SmsId { get; set; }
    public Sms? Sms { get; set; }
    public int? ProviderId { get; set; }
    public Provider? Provider { get; set; }
}