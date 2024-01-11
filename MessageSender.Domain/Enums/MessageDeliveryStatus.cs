namespace MessageSender.Domain.Enums;

public enum MessageDeliveryStatus
{
    SendingToProvider,
    SuccessFromProvider,
    DeliveredToUser,
    FailFromProvider,
    Fail,
    Unknown
}