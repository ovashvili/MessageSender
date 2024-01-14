using MessageSender.Domain.Enums;

namespace MessageSender.Application.Sms.Extensions;

/// <summary>
/// Provides extension methods for enums.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Converts an integer status value to a MessageDeliveryStatus enum value.
    /// </summary>
    /// <param name="status">The integer status value.</param>
    /// <returns>The MessageDeliveryStatus enum value.</returns>
    public static MessageDeliveryStatus ToMessageDeliveryStatus(this int status)
    {
        return status switch
        {
            0 => MessageDeliveryStatus.SendingToProvider,
            1 => MessageDeliveryStatus.SuccessFromProvider,
            2 => MessageDeliveryStatus.DeliveredToUser,
            3 => MessageDeliveryStatus.Fail,
            4 => MessageDeliveryStatus.FailFromProvider,
            5 => MessageDeliveryStatus.Unknown,
            _ => throw new InvalidOperationException($"Invalid status value: {status}")
        };
    }
}