using System.Text.Json.Serialization;

namespace MessageSender.NexmoIntegration.Models;

public class SmsMessage(string from, string to, string text)
{
    [JsonPropertyName("message_type")]
    public string MessageType { get; private set; } = "text";

    [JsonPropertyName("channel")]
    public string Channel { get; private set; } = "sms";

    [JsonPropertyName("text")]
    public string Text { get; private set; } = text;

    [JsonPropertyName("to")]
    public string To { get; private set; } = to;

    [JsonPropertyName("from")]
    public string From { get; private set; } = from;
}