namespace MessageSender.IntegrationsCommon.ProviderResults;

public class SmsProviderResult
{
    public string? MessageId { get; private set; }
    public string? Title { get; private set; }
    public string? ErrorMessage { get; private set; }

    public static SmsProviderResult Success(string messageId)
    {
        return new SmsProviderResult { MessageId = messageId };
    }

    public static SmsProviderResult Failure(string? title = null, string? errorMessage = null)
    {
        return new SmsProviderResult { Title = title, ErrorMessage = errorMessage };
    }
}