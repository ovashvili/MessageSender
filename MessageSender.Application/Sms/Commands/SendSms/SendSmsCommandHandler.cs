using MediatR;
using MessageSender.Service.Common.Models;

namespace MessageSender.Application.Sms.Commands.SendSms;

public class SendSmsCommandHandler : IRequestHandler<SendSmsCommand, Result<long>>
{
    public Task<Result<long>> Handle(SendSmsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}