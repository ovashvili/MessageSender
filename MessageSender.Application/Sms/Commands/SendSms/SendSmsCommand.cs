using MediatR;
using MessageSender.Service.Common.Models;

namespace MessageSender.Application.Sms.Commands.SendSms;

public class SendSmsCommand : IRequest<Result<long>>
{
    public string To { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? Provider { get; set; }
}