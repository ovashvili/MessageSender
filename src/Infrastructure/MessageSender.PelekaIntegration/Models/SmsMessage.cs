using System.Text.Json.Serialization;

namespace MessageSender.PelekaIntegration.Models;

public class SmsMessage
{
    public SmsMessage(string to, string text, string token)
    {
        PhoneNumber = to;
        Text = text;
        Token = token;
    }

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; private set; }

    [JsonPropertyName("text")]
    public string Text { get; private set; }

    [JsonPropertyName("token")]
    public string Token { get; private set; }
}