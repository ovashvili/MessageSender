using System.Text.Json.Serialization;

namespace MessageSender.PelekaIntegration.Models;

public class PelekaResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; } = null!;

    [JsonPropertyName("data")]
    public MessageData? Data { get; set; }

    [JsonPropertyName("message")]
    public string? ErrorMessage { get; set; }
}

public class MessageData
{
    [JsonPropertyName("message_id")]
    public int MessageId { get; set; }

    [JsonPropertyName("opaque")]
    public string? Opaque { get; set; }
}