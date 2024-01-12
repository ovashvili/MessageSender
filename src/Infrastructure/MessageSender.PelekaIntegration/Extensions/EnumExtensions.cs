using MessageSender.PelekaIntegration.Enums;

namespace MessageSender.PelekaIntegration.Extensions;

public static class EnumExtensions
{
    public static PelekaStatus ToPelekaStatus(this string @enum)
        => @enum switch
        {
            "OK" => PelekaStatus.Ok,
            "ERROR" => PelekaStatus.Error,
            _ => throw new InvalidOperationException($"Invalid status value: {@enum}")
        };
}