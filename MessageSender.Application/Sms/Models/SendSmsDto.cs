using System.Text.Json.Serialization;
using FluentValidation;

namespace MessageSender.Application.Sms.Models;

public class SendSmsDto
{
    [JsonPropertyName("to")]
    public string To { get; set; } = null!;

    [JsonPropertyName("content")]
    public string Content { get; set; } = null!;

    [JsonPropertyName("provider")]
    public string? Provider { get; set; }
}

public class SendSmsRequestValidator : AbstractValidator<SendSmsDto>
{
    public SendSmsRequestValidator()
    {
        RuleFor(r => r.To)
            .NotEmpty().WithMessage("Recipient phone number cannot be empty.");

        RuleFor(r => r.Content)
            .NotEmpty().WithMessage("SMS content cannot be empty.");
    }
}